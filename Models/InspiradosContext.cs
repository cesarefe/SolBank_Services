using Microsoft.EntityFrameworkCore;

namespace SolBank1.Models
{
    public class InspiradosContext : DbContext 
    {
        public InspiradosContext (DbContextOptions <InspiradosContext> options) : base(options)
        {

        }

        public DbSet <Inspirados> Inspirado { get; set; }
    }
}
