using Microsoft.EntityFrameworkCore;

namespace Pets.Models
{
    public class PetsDBContext : DbContext
    {
        public PetsDBContext(DbContextOptions<PetsDBContext> options) 
            : base(options)
        {
            
        }
        public DbSet<Pet> pets { get; set; }
    }
}
