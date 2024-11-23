using Microsoft.EntityFrameworkCore;
using Back_End_WebAPI.Models;
namespace Back_End_WebAPI.Data
{
    // Db Context, for each Model used there will need to be implemented a db set
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<HasRole> HasRoles { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;

        public DbSet<Request> Requests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HasRole>().HasKey(e => new { e.UserID, e.Role });

           

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Exam>().ToTable("Exams");
            modelBuilder.Entity<Request>().ToTable("Requests");
            modelBuilder.Entity<HasRole>().ToTable("HasRoles");
            modelBuilder.Entity<StudentGroup>().ToTable("StudentGroup");
            
           
           

        }
    }
}
