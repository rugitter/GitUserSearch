using System.Threading.Tasks;
using GitUserSearch.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitUserSearch.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Initialize controller by injecting DbContext
        public HistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: History
        // Display all user search history in a brief way
        public async Task<IActionResult> Index()
        {
            var searchHistory = _context.UserSearches.Include(s => s.User);

            return View(await searchHistory.ToListAsync());
        }

        // GET: History/Details/5
        // Display all details of a valid user via its user id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.GitUsers.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}