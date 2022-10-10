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
                var em = new Employe_Info()
                {
                   Name = employe.Name,
                    Address = employe.Address,
                    Mobile_No=employe.Mobile_No,
                    Salary=employe.Salary,
            
                };
                context.Employe_Infos.Add(em);
                context.SaveChanges();
                TempData["Error"] = "Data Saved Succesfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Error"] = "Empty field Cannot Create";
                return View();
            }
            
        }
        public IActionResult Delete(int id)
        {
            var emp=context.Employe_Infos.SingleOrDefault(c=>c.Id==id);
            context.Employe_Infos.Remove(emp);
            context.SaveChanges();
            TempData["Delete"] = "Data Delete Succesfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var empl=context.Employe_Infos.SingleOrDefault(c=>c.Id==id);
            var result = new Employe_Info()
            {
                Name = empl.Name,
                Address = empl.Address,
                Mobile_No = empl.Mobile_No,
                Salary = empl.Salary,

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Employe_Info model)
        {
            var emp = new Employe_Info()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Mobile_No = model.Mobile_No,
                Salary = model.Salary,
            };
            context.Employe_Infos.Update(emp);
            context.SaveChanges();
            TempData["Error"] = "Data Edit Succesfully";
            return RedirectToAction("Index");
        }
    }
}
