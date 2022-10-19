using System.ComponentModel.DataAnnotations;

namespace Mvc_Crud_Op.Models
{
    public class UplodImage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }  

    }
}
