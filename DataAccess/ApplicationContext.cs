using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataAccess.Contexts
{
    public class ApplicationContext : IdentityDbContext<Staff, IdentityRole<uint>, uint>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
        // Actors
        public DbSet<Patient> Patients { get; set; }

        // Others
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(a => a.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .IsRequired();

            // seed roles
            builder.Entity<IdentityRole<uint>>().HasData([
                new IdentityRole<uint> { Id = 1, Name= "Admin", NormalizedName = "ADMIN"},
                new IdentityRole<uint> { Id = 2, Name= "Doctor", NormalizedName = "DOCTOR"},
                new IdentityRole<uint> { Id = 3, Name= "Nurse", NormalizedName = "NURSE"},
            ]);

            var hasher = new PasswordHasher<Staff>();

            // add first admin
            builder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    firstName = "Admin",
                    lastName = "Team 4",
                    UserName = "SuperAdmin",
                    NormalizedUserName = "SUPERADMIN",
                    Email = "admin@depi.com",
                    NormalizedEmail = "ADMIN@DEPI.COM",
                    PasswordHash = hasher.HashPassword(null, "0123456789"),
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    LockoutEnabled = false,
                }
            );

            builder.Entity<IdentityUserRole<uint>>().HasData(new IdentityUserRole<uint>
            {
                RoleId = 1,
                UserId = 1
            });

            builder.Entity<IdentityUserClaim<uint>>().HasData(new IdentityUserClaim<uint>
            {
                Id = 1,
                UserId = 1,
                ClaimType = "Email",
                ClaimValue = "admin@depi.com"
            });

            base.OnModelCreating(builder);
        }
    }
}
