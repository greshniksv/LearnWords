using System.Data.Entity;
using LearnWords.Models;

namespace LearnWords.Contexts
{
    public class SqlDBContext : DBContext
    {
        public DbSet<ExistWord> ExistWords { get; set; }
    }
}