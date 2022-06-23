using Microsoft.AspNetCore.Mvc;
using Vatan.Business.Abstract;
using Vatan.Entity;
using Vatan.WebUI.Models;

namespace Vatan.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category()
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName,
                    CategoryDescription = model.CategoryDescription
                };

                _categoryService.Create(entity);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        public IActionResult DeleteCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryid)
        {
            var entity = _categoryService.GetById(categoryid);
            _categoryService.Delete(entity);
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetById(id);
            var model = new CategoryModel()
            {
               CategoryId = entity.CategoryId,
               CategoryName = entity.CategoryName,
               CategoryDescription = entity.CategoryDescription
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditCategory(CategoryModel entity)
        {
            Category model = new Category()
            {
                CategoryName = entity.CategoryName,
                CategoryDescription = entity.CategoryDescription
            };
            _categoryService.Update(model);
            return RedirectToAction("Index");
        }
    }
}
