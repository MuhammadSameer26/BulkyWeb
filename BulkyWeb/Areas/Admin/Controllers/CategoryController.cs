using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetALL();

            return View(objCategoryList);       
        }

        public IActionResult Create()
        {

           return View();
        }


        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
               ModelState.AddModelError("name", "The Display order cannot exactly match the Name.");
            }
            
            if (ModelState.IsValid)
            {
               _unitOfWork.Category.Add(obj);
               _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            var CategoryFromDb = _unitOfWork.Category.Get(id);

            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["sucess"] = "Category Updated successfuly";

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id==0 || id==null)
            {
                return NotFound();
            }
            var foundId = _unitOfWork.Category.Get(id.Value);

            return View(foundId);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id) 
        {
            Category? obj = _unitOfWork.Category.Get(id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["sucess"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index");
        }
       
    }
}
