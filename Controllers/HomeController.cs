using ContactsListDBWoodburn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ContactsListDBWoodburn.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }

        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var contacts = context.Contacts
                .Include(m => m.Comment)
                .OrderBy(m => m.Name)
                .ToList();
            return View(contacts);
        }
    }
}
