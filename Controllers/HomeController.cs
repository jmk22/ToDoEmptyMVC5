using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EmptyMVCAuthentication01.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Extensions;

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
                return View(db.TestModels.ToList());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("TestView");
            }
                
        }

        public IActionResult Details(int id)
        {
            TestModel testmodel = db.TestModels.FirstOrDefault(d=>d.Id==id);
            if (testmodel == null)
            {
                return View("Not found");
            }
            return View(testmodel);
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
        public IActionResult Edit(int id)
        {
            TestModel testmodel = db.TestModels.FirstOrDefault(d => d.Id == id);
            if (testmodel == null)
            {
                return View("Not found");
            }
            return View(testmodel);
        }
        [HttpPost]
        public IActionResult Edit(TestModel testmodel)
        {
            db.Entry(testmodel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            TestModel testmodel = db.TestModels.FirstOrDefault(d => d.Id == id);
            if (testmodel == null)
            {
                return View("Not found");
            }
            return View(testmodel);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            TestModel testmodel = db.TestModels.FirstOrDefault(d => d.Id == id);
            db.TestModels.Remove(testmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
