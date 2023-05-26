using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Data.SqlClient;
using Assignment2.Models;


namespace Assignment2.Controllers
{
    public class ProductController : Controller
    {
        private readonly productdbContext _context;

        public ProductController(productdbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.Product product)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Products.Any(p => p.ProductId == product.ProductId))
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(
                        nameof(product.ProductId), $"Product ID {product.ProductId} already exists.");
                }
            }
            return View(product);
        }
        
        public JsonResult CheckID(string product)
        {
            string msg = Check.IDExists(_context, product);
            if (string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }

        [HttpGet]
        public IActionResult Update()
        {
            var productIds = _context.Products.Select(p => p.ProductId).ToList();
            ViewBag.ProductIds = new SelectList(productIds);

            return View();
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult GetProductDetails(string productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Json(new
            {
                productName = product.ProductName,
                productDescription = product.ProductDescription,
                productPrice = product.ProductPrice
            });
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var products = _context.Products.ToList();
            return Json(products);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            var productIds = _context.Products.Select(p => p.ProductId).ToList();
            ViewBag.ProductIds = new SelectList(productIds);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Search(string keyword, decimal? minPrice, decimal? maxPrice)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.ProductName.Contains(keyword));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice <= maxPrice.Value);
            }

            var products = query.ToList();

            if (string.IsNullOrEmpty(keyword) && !minPrice.HasValue && !maxPrice.HasValue)
            {
                products = _context.Products.ToList();
            }

            return View(products);
        }
    }
}