using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EmptyMVCAuthentication01.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EmptyMVCAuthentication01.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("TestView");
            }
                
        }
        [HttpPost]
        public IActionResult Index(TestModel testmodel)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TestModel testmodel)
        {
            try
            {
                db.TestModels.Add(testmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }

    }
}
