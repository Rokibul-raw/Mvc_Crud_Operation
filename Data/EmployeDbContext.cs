using Microsoft.EntityFrameworkCore;
using Mvc_Crud_Op.Models;

namespace Mvc_Crud_Op.Data
{
    public class EmployeDbContext:DbContext
    {
        public EmployeDbContext(DbContextOptions<EmployeDbContext> options) : base(options) 
        { 

        }
        public DbSet<Employe_Info> Employe_Infos { get; set; }
        public DbSet<UplodImage> uplodImages { get; set; }

    }
}
