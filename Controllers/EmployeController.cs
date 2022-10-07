using Microsoft.AspNetCore.Mvc;
using Mvc_Crud_Op.Data;
using Mvc_Crud_Op.Models;

namespace Mvc_Crud_Op.Controllers
{
    public class EmployeController : Controller
    {
        private readonly EmployeDbContext context;

        public EmployeController(EmployeDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var result = context.Employe_Infos.ToList();

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }    
        [HttpPost]
        public IActionResult Create(Employe_Info employe)
        {
            if (ModelState.IsValid)
            {
                var employ = new Employe_Info()
                {
                    Name=employe.Name,
                    Address=employe.Address,
                    Mobile_No=employe.Mobile_No,
                    Salary=employe.Salary,
                   
                };
                context.Employe_Infos.Add(employ);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Error"] = "Empty field Cannot Create";
                return View();
            }
            
        }
    }
}
