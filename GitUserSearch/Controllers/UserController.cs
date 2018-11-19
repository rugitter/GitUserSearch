using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitUserSearch.Data;
using GitUserSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Octokit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitUserSearch.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

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

                await AddToDB(user);

                return View(user);
            }
            catch (NotFoundException objectNotFound)
            {
                TempData["Message"] = "No Valid User Found! Please Search Again!";

                return Redirect("index");
            // BadRequest($"Error getting user info from github : {ObjectNotFoundException.Message}");
            }
        }

        // An utility method to add new user to dbcontext and database
        // Only run when a search found a valid user
        private async Task AddToDB(User user)
        {
            try
            {
                // Check if newly searched user already exists in the DbContext
                var gitUser = _context.GitUsers.SingleOrDefault(u => u.Id == user.Id);

                // Create a new GitUser if not existing in the DbContext
                if (gitUser == null) {
                    gitUser = new GitUser
                    {
                        Login = user.Login,
                        Id = user.Id,
                        Url = user.Url,
                        Name = user.Name,
                        Location = user.Location,
                        Followers = user.Followers,
                        Company = user.Company,
                        Email = user.Email
                    };
                    _context.GitUsers.Add(gitUser);
                }

                // Create new search item using the searched user
                UserSearch search = new UserSearch { AccessDate = DateTime.Now, User = gitUser };
                _context.UserSearches.Add(search);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
