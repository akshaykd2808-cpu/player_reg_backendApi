using Microsoft.EntityFrameworkCore;
using playerregproject.Models;

namespace playerregproject.Data
{
    public class PlayerRegDbContext : DbContext
    {
        public PlayerRegDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Form> Forms { get; set; }

        public DbSet<CustomField> CustomFields { get; set; }

        public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
    }
}
