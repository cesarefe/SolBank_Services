using Microsoft.EntityFrameworkCore;

namespace SolBank1.Models
{
    public class dbconn : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura la cadena de conexión a tu base de datos
            optionsBuilder.UseSqlServer("Server=tcp:ivpserver.database.windows.net,1433;Database=inmvipi;Uid=admivpsvr;Pwd=admserverIvp$$;Encrypt=yes;TrustServerCertificate=no;Connection Timeout=30;");
        }

        // Agrega DbSet para cada tabla en tu base de datos
        // public DbSet<TuClase> NombreDeTabla { get; set; }
    }
}
