using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitofWork;
        public ProductController(IUnitOfWork _unitofWork)
        {
            unitofWork = _unitofWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> foundProducts = unitofWork.Products.GetALL();
            return View(foundProducts);
        }
    }
}
