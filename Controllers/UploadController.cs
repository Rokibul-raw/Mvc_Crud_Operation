using Microsoft.AspNetCore.Mvc;
using Mvc_Crud_Op.Data;
using Mvc_Crud_Op.Models;
using Mvc_Crud_Op.Models.ViewImage;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Mvc_Crud_Op.Controllers
{
    public class UploadController : Controller
    {
        private readonly EmployeDbContext context;
        private readonly IHostingEnvironment environment;

        public UploadController(EmployeDbContext context, IHostingEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadImage(ImageModel model)
        {
            if (ModelState.IsValid)
            {
                var path = environment.WebRootPath;
                var filePath = "Content/image" + model.ImgPath.FileName;
                var fullPath=Path.Combine(path, filePath);
                UploadFile(model.ImgPath, fullPath);
                var img = new UplodImage()
                {
                    Name = model.Name,
                    ImgPath = filePath,
                };
                context.Add(img);
                context.SaveChanges();
                return RedirectToAction("Index");
              
            }
            else
            {
                return View(model);
            }

        }
        public void UploadFile(IFormFile file ,string path)
        {
            FileStream stream=new FileStream(path, FileMode.Create);
            file.CopyTo(stream);

        }

        public IActionResult Index()
        {
            var data = context.uplodImages.ToList();
            return View(data);
        }
        public IActionResult Delete(int id)
        {
            var dlte=context.uplodImages.SingleOrDefault(x => x.Id == id);
            context.uplodImages.Remove(dlte);
            context.SaveChanges();
            TempData["Delete"] = "Image Delete Succesfully";
            return RedirectToAction("Index");
        }
    }
}
