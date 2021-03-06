using Microsoft.EntityFrameworkCore;

namespace MyBookStore.Models
{
    public class MBS_DBContext : DbContext
    {
        public MBS_DBContext(DbContextOptions<MBS_DBContext> options) : base(options)
        {
           
        }

        //entity
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
