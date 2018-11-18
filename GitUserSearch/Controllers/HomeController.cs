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

        //public async Task<IActionResult> ShowAllUsers()
        //{
        //    List<Octokit.User> users = new List<Octokit.User>();
            
        //    try
        //    {
        //        string url = "https://api.github.com/users";
        //        var client = new HttpClient();
        //        client.BaseAddress = new Uri("https://api.github.com/users");
        //        //var client = new GitHubClient(new ProductHeaderValue("MyDemoApp"));
                
        //            var response = await client.GetAsync($"/users");
        //            response.EnsureSuccessStatusCode();

        //            var stringResult = await response.Content.ReadAsStringAsync();
        //            var rawWeather = JsonConvert.DeserializeObject<List<Octokit.User>>(stringResult);
        //            return View(users);
        //        }
        //        catch (HttpRequestException httpRequestException)
        //        {
        //            return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
        //        }

        //        //var rawJSON = string.Empty;
        //        //rawJSON = webClient.DownloadString(url);
                
        //        //users = JsonConvert.DeserializeObject<List<Octokit.User>>(rawJSON);

        //        //return View(users);
        //    }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
