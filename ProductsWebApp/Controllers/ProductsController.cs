using Microsoft.AspNetCore.Mvc;
using ProductsWebApp.Models;
using ProductsWebApp.Services;

namespace ProductsWebApp.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _productService.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id, string subCategory)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(subCategory))
                return BadRequest();

            var product = await _productService.GetAsync(id, subCategory);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _productService.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id, string subCategory)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(subCategory))
                return BadRequest();

            await _productService.DeleteAsync(id, subCategory);
            return RedirectToAction(nameof(Index));
        }

    }
}
