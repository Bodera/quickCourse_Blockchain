using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EcommerceApp.Models;
using EcommerceApp.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext<ChatHub> HubContext { get; set; }

        public HomeController(IHubContext<ChatHub> hubcontext)
        {
            HubContext = hubcontext;
        }

        public IActionResult Index()
        {
            var catalogue = ListVideo.Videos();
            ViewBag.Videos = catalogue;
            return View();
        }

        //localhost = ::1
        public async Task<IActionResult> ApiCall(string ip, int id)
        {
            await this.HubContext.Clients.All.SendAsync(ip, id, ListVideo.Videos().First(x => x.Id == Convert.ToInt32(id)));
            
            VideoOwned.AddUser(ip, id);

            return Content("successfull");
        }

        public IActionResult QrGenerate()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
