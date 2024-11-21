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

        // Branch 51
        public DbSet<Attends> Attends { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Teaches> Teaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<HasRole>().ToTable("HasRoles");
            modelBuilder.Entity<StudentGroup>().ToTable("StudentGroup");
            modelBuilder.Entity<Subject>().ToTable("Subjects");
            modelBuilder.Entity<Exam>().ToTable("Exams");

            //Branch 51

            modelBuilder.Entity<Attends>().HasKey(e => new { e.UserID, e.ExamID });
            modelBuilder.Entity<Request>().HasKey(e => new { e.UserID, e.ExamID });
            modelBuilder.Entity<Teaches>().HasKey(e => new { e.UserID, e.SubjectID });

            modelBuilder.Entity<Attends>().ToTable("Attends");
            modelBuilder.Entity<Request>().ToTable("Requests");
            modelBuilder.Entity<Teaches>().ToTable("Teaches");

        }
    }
}
