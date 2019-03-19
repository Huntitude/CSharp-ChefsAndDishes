using Microsoft.EntityFrameworkCore;
namespace chefsNdishes.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}

        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}

    }
    
}