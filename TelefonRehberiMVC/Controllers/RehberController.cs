using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using TelefonRehberiMVC.Models;
using TelefonRehberiMVC.Models.MVCDbContext;

namespace TelefonRehberiMVC.Controllers
{
    public class RehberController : Controller
    {
        private readonly TelefonRehberiDbContext _context;

        public RehberController(TelefonRehberiDbContext context)
        {
            _context = context;
        }// constructor  (yapıcı method)uygulandı.

        public IActionResult Index(string SearchName = null)
        {
            if (String.IsNullOrEmpty(SearchName))
            {
                var model = new PersonelViewModel
                {
                    personelList = _context.Persons.Include(x => x.Phones).ToList(),
                    SearchName = SearchName
                };
                return View(model);
            }
            else
            {
                var model = new PersonelViewModel
                {
                    SearchName = SearchName,
                    personelList = _context.Persons
                                   .Where(p => p.Ad.Contains(SearchName) || p.Ad.Contains(SearchName))
                                   .Include(x => x.Phones).ToList()
                                   .ToList(),
                   
                };
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Persons persons)
        {


             await _context.Phones.AddAsync(new Phone
            {
                Numara = persons.Phones.Numara
            });

            var telefon = _context.Phones.Where(x => x.Numara == persons.Phones.Numara).FirstOrDefault();
            persons.PhoneId = telefon.Id;
             
            _context.Persons.Add(persons);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }//asp-route

        [HttpGet]
        public IActionResult Güncelle(int Id)
        {
            var kisiler = _context.Persons.Include(x => x.Phones).ToList();
            var model = _context.Persons.Find(Id);
            return View(model);
            ;
            //var kisiler = _context.Persons.ToList(Id);
            //return View(kisiler);

        }

        [HttpPost]
        public IActionResult Güncelle(Persons persons)
        {
            //Persons person  = _context.Persons.Find(persons.Id);
            //   _context.SaveChanges();
            //   return RedirectToAction("Index");

            _context.Update(persons);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Sil(int Id)
        {
            //Persons persons= _context.Persons.Find(Id);
            //  _context.Persons.Remove(persons);
            //  _context.SaveChanges();
            //  return RedirectToAction("Index");
            var kisiler = _context.Persons.Include(x => x.Phones).ToList();
            var model = _context.Persons.Find(Id);
            _context.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        //public IActionResult Ara(string searchTerm)
        //{
        //    // searchTerm parametresini kullanarak arama işlemlerini gerçekleştirin
        //    // Örneğin, veritabanında arama yapabilir veya başka bir kaynağı sorgulayabilirsiniz

        //    // Sonuçları bir modele ekleyerek, bir görünüme gönderin
        //    var searchResults = PerformSearch(searchTerm);
        //    return View("Index", searchResults);
        //}

        //private List<Persons> PerformSearch(string searchTerm)
        //{

        //    var results = _context.Persons
        //        .Where(p => p.Ad.Contains(searchTerm) || p.Ad.Contains(searchTerm))
        //        .Include(x => x.Phones).ToList()
        //        .ToList();

        //    return results;
        //}
    }
}


