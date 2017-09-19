using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationWithoutIdentity.Controllers
{
    public class AccountController : Controller
    {
        List<ApplicationUser> users = new List<ApplicationUser> {
            new ApplicationUser{UserName = "hoge", Password = "1234"},
            new ApplicationUser{UserName = "piyo", Password = "5678"}
        };

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        // ユーザーがログインする作業を行い、ApplicationUser オブジェクトと文字列 returnUrl を受け取ります。
        // このメソッドは[HttpPost]属性で修飾されているため、http POSTアクションなしでは呼び出すことはできません。
        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser user, string returnUrl = null)
        {
            const string badUserNameOrPasswordMessage = "Username or password is incorrect.";
            if (user == null)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            // ユーザー名が一致するユーザーを抽出
            var lookupUser = users.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (lookupUser == null)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            // パスワードの比較
            if (lookupUser?.Password != user.Password)
            {
                return BadRequest(badUserNameOrPasswordMessage);
            }

            // Cookies 認証スキームで新しい ClaimsIdentity を作成し、ユーザー名を追加します。
            var identity = new ClaimsIdentity("MyCookieAuthenticationScheme");
            identity.AddClaim(new Claim(ClaimTypes.Name, lookupUser.UserName));

            // クッキー認証スキームと、上の数行で作成されたIDから作成された新しい ClaimsPrincipal を渡します。
            await HttpContext.SignInAsync("MyCookieAuthenticationScheme", new ClaimsPrincipal(identity));

            if (returnUrl == null)
            {
                returnUrl = TempData["returnUrl"]?.ToString();
            }
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            //return LocalRedirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuthenticationScheme");

            return RedirectToAction("Index", "Home");
        }
    }
}
