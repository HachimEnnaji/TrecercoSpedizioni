using Microsoft.EntityFrameworkCore;
using TrecercoSpedizioni.Models;

namespace TrecercoSpedizioni.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clienti { get; set; }
    }
}
