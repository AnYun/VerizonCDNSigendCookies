using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VerizonCDNSigendCookies.Models;

namespace VerizonCDNSigendCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetToken()
        {
            var generator = new ECTokenGenerator();
            var key = "{Your Key}";

            var expireTime = DateTime.UtcNow.AddMinutes(5);
            string clientIp = HttpContext.Connection.RemoteIpAddress.ToString();
            var token = generator.EncryptV3(key, expireTime, clientIp);

            Response.SetTokenCookies(token);

            var decryptdToken = generator.DecryptV3(key, token, false);
            NameValueCollection qscoll = HttpUtility.ParseQueryString(decryptdToken);
            TempData["token"] = qscoll;

            TempData["Message"] = "Set Token OK!";
            return View();
        }

        public IActionResult RemoveToken()
        {
            Response.SetTokenCookies("", true);
            TempData["Message"] = "Remove Token OK!";
            return RedirectToAction("Index");
        }

        public IActionResult eBooks(string page)
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
