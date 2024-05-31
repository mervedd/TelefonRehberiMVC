using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TelefonRehberiMVC.Models;
using TelefonRehberiMVC.Models.MVCDbContext;

namespace TelefonRehberiMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TelefonRehberiDbContext _context;

        public HomeController(TelefonRehberiDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string DepartmanId, string BirimId, string Ad)
        {
            var personelListe = new List<Persons>();
            if (!String.IsNullOrEmpty(DepartmanId))
            {
                personelListe = (_context.Persons
                               .Where(p => p.Departman == DepartmanId)
                               .Include(x => x.Phones).ToList()
                               .ToList());
            }
            if (!String.IsNullOrEmpty(BirimId))
            {
                personelListe = (_context.Persons
                                 .Where(p => p.Birim == BirimId)
                                 .Include(x => x.Phones).ToList()
                                 .ToList());
            }
            if (!String.IsNullOrEmpty(Ad))
            {
                personelListe = (_context.Persons
                                .Where(p => p.Ad == Ad)
                                .Include(x => x.Phones).ToList()
                                .ToList());
            }


            var model = new HomeViewModel
            {
                Ad = Ad,
                DepartmanId = DepartmanId,
                personelList = personelListe
            };

            return View(model);
        }
    }
}