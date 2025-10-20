using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }
        public IActionResult Index()
        {
           IEnumerable<Category> objCategoryList = categoryRepository.GetALL();

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
               categoryRepository.Add(obj);
               categoryRepository.Save();
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
            var CategoryFromDb = categoryRepository.Get(id);

            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(obj);
                categoryRepository.Save();
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
            var foundId = categoryRepository.Get(id.Value);

            return View(foundId);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id) 
        {
            Category? obj = categoryRepository.Get(id);
            if (obj == null)
            {
                return NotFound();
            }

            categoryRepository.Remove(obj);
            categoryRepository.Save();
            TempData["sucess"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index");
        }
       
    }
}
