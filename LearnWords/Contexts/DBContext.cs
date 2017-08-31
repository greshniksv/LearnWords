using System.Data.Entity;
using LearnWords.Models;

namespace LearnWords.Contexts
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserWord> UserWords { get; set; }
    }
}