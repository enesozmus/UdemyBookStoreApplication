using Microsoft.AspNetCore.Mvc;
using Udemy.Business;
using Udemy.Models.Entities;

namespace Udemy.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _unitOfWork.Category.GetAll();
            return View(categoryList);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            //
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","aynı olamaz mı");
                ModelState.AddModelError("displayorder","geldi mi");
            }
            //
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int? id)
        {
                if (id == null  || id == 0) { return NotFound(); }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(x=> x.Id == id);            // => gelen id'li kategoriyi bul
                if (categoryFromDb == null) { return NotFound("yok"); }
            return View(categoryFromDb);                                                    // => bulduğun kategoriyi yolla
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString()) { ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name!"); }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);            // => gelen id'li kategoriyi bul
            if (categoryFromDb == null) { return NotFound("yok"); }
            return View(categoryFromDb);                                                    // => bulduğun kategoriyi yolla
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
                if (category == null) return NotFound();

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
                return RedirectToAction("Index");
        }
        #endregion

    }
}