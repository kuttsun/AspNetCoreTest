using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

namespace SignalR.Models.SignalR
{
    public class SignalRTest : Hub
    {
        public Task Send(string data)
        {
            // 接続している人にブロードキャストで送信
            return Clients.All.InvokeAsync("AddMessage", data);
        }
    }
}
