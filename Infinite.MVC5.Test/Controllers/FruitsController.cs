using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infinite.MVC5.Test.Models;
using System.Data.Entity;

namespace Infinite.MVC5.Test.Controllers
{
    public class FruitsController : Controller
    {
        private readonly ApplicationDbContext _context = null;

         public FruitsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Fruits
        public ActionResult Index()
        {
            var fruits = _context.Fruit.ToList();
            return View(fruits);
        }
        public ActionResult Details(int id)
        {
            var product = _context.Fruit.Include(c => c.CategoryName).Include(s=>s.PackSizeName).FirstOrDefault(p => p.Id == id);
            if (product!= null)
            {
                return View(product);

            }
            return HttpNotFound();


        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _context.Fruit.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                var packs = _context.Packs.ToList();
                ViewBag.Packs = packs;
                //return View(product);

                var categories = _context.categories.ToList();
                ViewBag.categories = categories;
                return View(product);
            }
            return HttpNotFound("Index");
        }
        [HttpPost]
        public ActionResult Edit(Fruits fruits)
        {
            if (fruits != null)
            {
                var fruitInDb = _context.Fruit.Find(fruits.Id);
                if (fruitInDb != null)
                {
                    fruitInDb.Id = fruits.Id;
                    fruitInDb.ProductName = fruits.ProductName;
                    fruitInDb.Price = fruits.Price;
                    fruitInDb.PackSizeId = fruits.PackSizeId;
                    fruitInDb.Quantity = fruits.Quantity;
                    fruitInDb.Discount = fruits.Discount;
                    fruitInDb.TotalPrice = fruits.TotalPrice;
                    fruitInDb.CategoryId = fruits.CategoryId;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            var Categories = _context.categories.ToList();
            ViewBag.Categories = Categories;
            return View(fruits);
        }
        




    }
}