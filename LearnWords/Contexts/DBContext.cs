using System.Data.Entity;
using LearnWords.Models;
using LearnWords.Models.Db;

namespace LearnWords.Contexts
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserWord> UserWords { get; set; }
    }
}