using ClientManagementAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Auto> Autos { get; set; }

    }


}
