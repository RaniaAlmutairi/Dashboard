using DashboardProject.Data;
using DashboardProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DashboardProject.Controllers
{
    public class HomeController :  Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // لتخزين المرفقات
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            //Authrized
            var username = HttpContext.User.Identity.Name ?? null;
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append("userdata", username, cookie);
            ViewBag.Username = Request.Cookies["userdata"];
            var prod = _context.products.ToList();
            ViewBag.Products = prod;
            return View(prod);
        }
        //------------------------------------------AddProduct---------------------------------
        public IActionResult AddNewItem(Product product)
        {
            ViewBag.Username = Request.Cookies["userdata"];
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("AddNewItem");
            }
            var p = _context.products.ToList();
            return View("AddNewItem", p);

        }
        //---------------------------------------Delete------------------------------------------
        [HttpPost]
        public JsonResult Delete(int record_no)
        {
            var productdel = _context.products.SingleOrDefault(p => p.Id == record_no);

            if (productdel != null)
            {
                Console.WriteLine("Product found, deleting...");
                _context.products.Remove(productdel);
                _context.SaveChanges();
                return Json(new { deleteMessage = "The product has been deleted" });
            }
            else
            {
                Console.WriteLine("Product not found, unable to delete");
                return Json(new { deleteMessage = "Failed to delete the product" });
            }
        }
        //---------------------------------------Delete2------------------------------------------
        [HttpPost]
        public JsonResult Delete2(int record_no)
        {
            var productdel = _context.productsDetails.SingleOrDefault(p => p.Id == record_no);

            if (productdel != null)
            {
                Console.WriteLine("Product found, deleting...");
                _context.productsDetails.Remove(productdel);
                _context.SaveChanges();
                return Json(new { deleteMessage = "The product has been deleted" });
            }
            else
            {
                Console.WriteLine("Product not found, unable to delete");
                return Json(new { deleteMessage = "Failed to delete the product" });
            }
        }
        //---------------------------------------Delete3------------------------------------------
        [HttpPost]
        public JsonResult Delete3(int record_no)
        {
            var productdel = _context.damagedProduct.SingleOrDefault(p => p.Id == record_no);

            if (productdel != null)
            {
                Console.WriteLine("Product found, deleting...");
                _context.damagedProduct.Remove(productdel);
                _context.SaveChanges();
                return Json(new { deleteMessage = "The product has been deleted" });
            }
            else
            {
                Console.WriteLine("Product not found, unable to delete");
                return Json(new { deleteMessage = "Failed to delete the product" });
            }
        }
        //----------------------------------------GetDataForUpdating----------------------------------
        [HttpPost]
        public JsonResult GetData(int id)
        {
            var p = _context.products.SingleOrDefault(p => p.Id == id);
            if (p != null)
            {
                return Json(p);
            }
            else
            {
                return Json(null);
            }

        }
        //-----------------------------------------UpdateData---------------------------------------------
        public IActionResult Update(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.products.Update(p);
                _context.SaveChanges();
            }
            return RedirectToAction("AddNewItem");
        }
        //---------------------------------------CreateProductDetails----------------------------
        public IActionResult CreateDetails(ProductDetails productDetails, IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return Content("File Not Selected");
            }

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", photo.FileName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                photo.CopyTo(stream);
                stream.Close();
            }

            productDetails.Images = photo.FileName;
            _context.productsDetails.Add(productDetails);
            _context.SaveChanges();
            return RedirectToAction("ProductsDetails");
        }
        ////------------------------------------------ProductDetails-----------------------------------
        public IActionResult ProductsDetails()
        {
            ViewBag.Username = Request.Cookies["userdata"];
            var ProductDetails = _context.productsDetails.Join(

                _context.products,

                productsdetails => productsdetails.ProductId,
                product => product.Id,

                (productsdetails, product) => new
                {
                    id = productsdetails.Id,
                    name = product.Name,
                    color = productsdetails.Color,
                    price = productsdetails.Price,
                    qty = productsdetails.Qty,
                    img = productsdetails.Images,
                }



                ).ToList();

            var prodcts = _context.products.ToList();

            ViewBag.products = prodcts;
            ViewBag.ProductDetails = ProductDetails;
            return View();
        }
        //----------------------------------------GetDataForUpdating----------------------------------
        [HttpPost]
        public JsonResult GetData2(int id)
        {
            var p = _context.productsDetails.SingleOrDefault(p => p.Id == id);
            if (p != null)
            {
                return Json(p);
            }
            else
            {
                return Json(null);
            }

        }
        //----------------------------------------Updating----------------------------------
        [HttpPost]
        public IActionResult Update2(ProductDetails vm, IFormFile? newImage)
        {


            if (ModelState.IsValid)
            {
                var productDetails = _context.productsDetails.Find(vm.Id);
                if (productDetails == null)
                {
                    return NotFound();
                }

                productDetails.Color = vm.Color;
                productDetails.Qty = vm.Qty;
                productDetails.Price = vm.Price;
                productDetails.ProductId = vm.ProductId;

                if (newImage != null && newImage.Length > 0)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "img", newImage.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        newImage.CopyTo(stream);
                    }
                    productDetails.Images = newImage.FileName;
                }

                _context.productsDetails.Update(productDetails);
                _context.SaveChanges();
                return RedirectToAction("ProductsDetails");
            }
            return View(vm);
        }


        //------------------------------------------AddDamageProduct--------------------------------------------
        public IActionResult AddDemag(DamagedProducts damege)
        {


            _context.Add(damege);
            _context.SaveChanges();

            return RedirectToAction("Demag");
        }
        //----------------------------------------Updating----------------------------------
        public IActionResult Update3(DamagedProducts p)
        {
            if (ModelState.IsValid)
            {
                _context.damagedProduct.Update(p);
                _context.SaveChanges();
            }
            return RedirectToAction("Demag");
        }

        //------------------------------------------ShowDamageProductDetails--------------------------------------
        public IActionResult Demag()
        {
            ViewBag.Username = Request.Cookies["userdata"];
            var products = _context.products.ToList();

            var Productsdemage = _context.damagedProduct.Join
                (
                     _context.products,

                      demag => demag.ProductId,
                      products => products.Id,


                     (demag, products) => new
                     {
                         demag,
                         products
                     }

                ).Join
                (
                  _context.productsDetails,

                  p => p.demag.ProductId,
                  c => c.ProductId,

                  (p, c) => new
                  {
                      id = p.demag.Id,
                      name = p.products.Name,
                      color = c.Color,
                      qty = p.demag.Qty
                  }
                  ).ToList();
            ViewBag.products = products;
            ViewBag.damage = Productsdemage;


            return View();
        }
        //----------------------------------------GetDataForUpdating--------------------------------------------------
        [HttpPost]
        public JsonResult GetData3(int id)
        {
            var p = _context.damagedProduct.SingleOrDefault(p => p.Id == id);
            if (p != null)
            {
                return Json(p);
            }
            else
            {
                return Json(null);
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
