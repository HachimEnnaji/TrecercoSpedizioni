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
        public DbSet<Spedizioni> Spedizioni { get; set; }
        public DbSet<DettagliSpedizioni> DettagliSpedizioni { get; set; }
    }

}
