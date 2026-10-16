using DAL.Entities;
using DNTPrac_447.Common;
using DNTPrac_447.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Abstraction;

namespace DNTPrac_447.Controllers
{
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ICustom _custom;

        public ProductController(IProductRepository productRepo, ICategoryRepository categoryRepo, ICustom custom)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _custom = custom;

            _custom.Increment();
        }

        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            ViewBag.categories = getCategories();
            var product = _productRepo.GetProductById(id);
            ProductViewModel productVM = new ProductViewModel();
            productVM.ProductId = product.ProductId;
            productVM.ProductCode = product.ProductCode;
            productVM.ProductName = product.ProductName;
            productVM.ProductPrice = Convert.ToInt32(product.Price);
            productVM.CategoryId = Convert.ToInt16(product.CategoryId);
            return View(productVM);
        }
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
           _productRepo.DeleteProduct(id);
           return RedirectToAction("ProductList");
        }
        [HttpGet]
        [Route("Create")]
       // [CustomFilter]
        public IActionResult Create()
        {
            string s = "Pradeep";
            string d = s.FormatString();
            ViewBag.categories = getCategories();
            return View();
        }
        [Route("Update")]
        public IActionResult Update(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductId = Convert.ToInt16(productVM.ProductId),
                    ProductCode = productVM.ProductCode,
                    ProductName = productVM.ProductName,
                    Price = productVM.ProductPrice,
                    CategoryId = productVM.CategoryId,
                };
                _productRepo.UpdateProduct(product);
                return RedirectToAction("ProductList", product);
            }
            ViewBag.categories = getCategories();
            return View("ProductList");
        }

        [Route("SaveProduct")]
        public IActionResult SaveProduct(ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductId = Convert.ToInt16(productVM.ProductId),
                    ProductCode = productVM.ProductCode,
                    ProductName = productVM.ProductName,
                    Price = productVM.ProductPrice,
                    CategoryId = productVM.CategoryId,
                };
                _productRepo.AddProduct(product);
                return RedirectToAction("ProductList", product);
            }
            ViewBag.categories = getCategories();
            return View("Create");
        }
        [Route("ProductList")]
        public IActionResult ProductList(int view)
        {
            var products = _productRepo.GetAllProducts();
            List<ProductViewModel> productVM = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productVM.Add(new ProductViewModel()
                {
                    ProductId = Convert.ToInt16(product.ProductId),
                    ProductCode = product.ProductCode,
                    ProductName = product.ProductName,
                    ProductPrice = Convert.ToInt32(product.Price),
                    CategoryId = product.CategoryId
                });
            }
            if (view == 0)
            {
                return View("ProductList", productVM);
            }
            else
            {
                return View("ProductCardList", productVM);
            }
        }
        private SelectList getCategories()
        {
            var categories = _categoryRepo.GetAllCategories().ToList();
            List<CategoryViewModel> categoryVM = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                categoryVM.Add(new CategoryViewModel()
                {
                    CategoryId = Convert.ToInt16(category.CategoryId),
                    CategoryName = category.CategoryName,
                });
            }
            return new SelectList(categoryVM, "CategoryId", "CategoryName");
        }
    }
}
