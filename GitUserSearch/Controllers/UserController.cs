using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Octokit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitUserSearch.Controllers
{
    public class UserController : Controller
    {
        // GET: User/
        public IActionResult Index()
        {
            return View();
        }

        // GET: User/Search?username=<username>
        public async Task<IActionResult> Search(string username)
        {
            try
            {
                var github = new GitHubClient(new ProductHeaderValue("MyDemoApp"));
                var user = await github.User.Get(username);
                return View(user);
            }
            catch (NotFoundException objectNotFound)
            {
                TempData["Message"] = "Failed to get user info : " + objectNotFound.Message;

                return Redirect("index");
            // BadRequest($"Error getting user info from github : {ObjectNotFoundException.Message}");
            }
        }
    }
}
