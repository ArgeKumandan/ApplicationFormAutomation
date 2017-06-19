using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationFormAutomation.WebUI.Models
{
    public class FormBuilderDbContext : DbContext
    {
        public FormBuilderDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Form> Form { get; set; }
        public DbSet<FormElement> FormElements { get; set; }
    }
}
