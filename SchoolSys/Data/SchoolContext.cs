using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSys.Data
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string STUDENT_ID = "a18be9a0-ad65-4ff8-ac17-11bd9344e575";
            const string TEACHER_ID = "a1ade9a1-4565-4aac-ac17-11bd9344e575";

            const int PersonStudentId = 1;
            const int PersonTeacherId = 2;

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ID, Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole { Id = STUDENT_ID, Name = "Student", NormalizedName = "Student".ToUpper() },
                new IdentityRole { Id = TEACHER_ID, Name = "Teacher", NormalizedName = "Teacher".ToUpper() }
                );

            var hasher = new PasswordHasher<ApplicationUser>();

            //var student = new Student
            //{
            //    Id = PersonStudentId,
            //    FirstName = "David",
            //    LastName = "Strong",
            //    PESEL = "124299135",
            //    Address = "1974 Raccoon Run, Seattle, Washington(WA)",
            //    TelephoneNumber = "2068923360",
                
            //};

            //var teacher = new Teacher()
            //{
            //    Id = PersonTeacherId,
            //    FirstName = "Jennifer",
            //    LastName = "Atencio",
            //    PESEL = "121190134",
            //    Address = "4035 Wood Street, New Orleans, Louisiana(LA)",
            //    TelephoneNumber = "9857862004"
            //};

            //modelBuilder.Entity<Student>().HasData(new Student
            //{
            //    Id = PersonStudentId,
            //    FirstName = "David",
            //    LastName = "Strong",
            //    PESEL = "124299135",
            //    Address = "1974 Raccoon Run, Seattle, Washington(WA)",
            //    TelephoneNumber = "2068923360",

            //});
            //modelBuilder.Entity<Teacher>().HasData(new Teacher
            //{
            //    Id = PersonTeacherId,
            //    FirstName = "Jennifer",
            //    LastName = "Atencio",
            //    PESEL = "121190134",
            //    Address = "4035 Wood Street, New Orleans, Louisiana(LA)",
            //    TelephoneNumber = "9857862004"
            //});



            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com".ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin"),
                SecurityStamp = string.Empty
            }
            //new ApplicationUser
            //{
            //    Id = STUDENT_ID,
            //    UserName = "student@student.com",
            //    NormalizedUserName = "student@student.com".ToUpper(),
            //    Email = "student@student.com",
            //    NormalizedEmail = "student@student.com".ToUpper(),
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "student"),
            //    SecurityStamp = string.Empty,
                

            //},
            // new ApplicationUser
            // {
            //     Id = TEACHER_ID,
            //     UserName = "teacher@teacher.com",
            //     NormalizedUserName = "teacher@teacher.com".ToUpper(),
            //     Email = "teacher@teacher.com",
            //     NormalizedEmail = "teacher@teacher.com".ToUpper(),
            //     EmailConfirmed = true,
            //     PasswordHash = hasher.HashPassword(null, "teacher"),
            //     SecurityStamp = string.Empty,
                 
            // }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ID,
                UserId = ADMIN_ID
            }
            //new IdentityUserRole<string>
            //{
            //    RoleId = STUDENT_ID,
            //    UserId = STUDENT_ID
            //},
            //new IdentityUserRole<string>
            //{
            //    RoleId = TEACHER_ID,
            //    UserId = TEACHER_ID
            //}
            );
                
        }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<IdentityRole>().HasData(
        //        new { Id = "1", Name = "Student", NormalizedName= "STUDENT"}
        //        );
        //}

        public DbSet<Class> Classes { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
