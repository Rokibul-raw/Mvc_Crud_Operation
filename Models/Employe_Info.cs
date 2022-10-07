using System.ComponentModel.DataAnnotations;

namespace Mvc_Crud_Op.Models
{
    public class Employe_Info
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile_No { get; set; }
        public string Salary { get; set; }

    }
}
