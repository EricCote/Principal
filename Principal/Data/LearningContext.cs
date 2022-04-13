using Microsoft.EntityFrameworkCore;
using Principal.Models;

namespace Principal.Data
{
    public partial class LearningContext : DbContext
    {
        public LearningContext() { }


        public LearningContext(DbContextOptions options) : base(options) { }


        public virtual DbSet<Course> Courses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Learning");
            }
        }
    }
}
