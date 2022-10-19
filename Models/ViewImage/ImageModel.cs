using System.ComponentModel.DataAnnotations;

namespace Mvc_Crud_Op.Models.ViewImage
{
    public class ImageModel
    {
        public int Id { get; set; }
        [Reqiured(ErrorMessage="Please Enter Name")]
        public string Name { get; set; }
        [Reqiured(ErrorMessage = "Please Choose ImagePath")]
        [Display(Name="Chose Image")]
        public IFormFile ImgPath { get; set; }  
    }
}
