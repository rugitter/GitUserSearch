using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GitUserSearch.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Octokit;

namespace GitUserSearch.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult ShowAllUsers()
        {
            List<Models.User> users = new List<Models.User>();
            var url = "https://api.github.com/users";

            using (var webClient = new WebClient())
            {
                var rawJSON = string.Empty;
                rawJSON = webClient.DownloadString(url);
                
                //users = JsonConvert.DeserializeObject<List<User>>(rawJSON);

                return View(users);
            }
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
