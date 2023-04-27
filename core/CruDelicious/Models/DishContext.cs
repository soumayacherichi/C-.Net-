using Microsoft.EntityFrameworkCore;



namespace CRUDelicious.Models

{

    public class DeliciousContext : DbContext

    {

        public DeliciousContext(DbContextOptions options) : base(options) {}

        public DbSet<Dish> Dishes {get;set;}

    }

}