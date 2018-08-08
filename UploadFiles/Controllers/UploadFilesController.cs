using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UploadFiles.Controllers
{
    public class UploadFilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            // ファイルサイズの取得
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            // 一時ファイルへのパスを取得
            var filePath = Path.GetTempFileName();

            foreach (var file in files)
            {
                // ファイルが空でない場合
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        // ファイルの内容をストリームにコピー
                        await file.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }

        public IActionResult Download()
        {
            var str = "{ \"foo\" : \"test\" }";
            var filename = "Result-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".json";

            //ファイルをダウンロード
            return File(new MemoryStream(Encoding.UTF8.GetBytes(str)), "application/json", filename);
        }
    }
}