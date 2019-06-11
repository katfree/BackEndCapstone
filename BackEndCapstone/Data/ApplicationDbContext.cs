using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Models;
using Microsoft.AspNetCore.Identity;


namespace BackEndCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<WatchParty> WatchParty { get; set; }
        public DbSet<Sport> Sport { get; set; }
        public DbSet<PartyAttendee> PartyAttendee { get; set; }
        public DbSet<Team> Team { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            

            // Restrict deletion of related watchparty when PartyAttendees entry is removed
            modelBuilder.Entity<WatchParty>()
                .HasMany(o => o.PartyAttendees)
                .WithOne(l => l.WatchParty)
                .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                UserName = "admin",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "123456");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            

            modelBuilder.Entity<Sport>().HasData(
                new Sport()
                {
                    SportId = 1,
                    Name = "Hockey"
                    
                },
                new Sport()
                {
                    SportId = 2,
                    Name = "Soccer"
                },
                new Sport()
                {
                    SportId = 3,
                    Name = "Football"
                },
                new Sport()
                {
                    SportId = 4,
                    Name = "Baseball"
                },
                new Sport()
                {
                    SportId = 5,
                    Name = "Basketball"
                }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team()
                {
                    TeamId = 1,
                    Name = "Nashville Predators",
                    SportId = 1
                    
                },
                new Team()
                {
                    TeamId = 2,
                    Name = "Nashville Sounds",
                    SportId = 4

                },
                
                new Team()
                {
                    TeamId = 3,
                    Name = "Tennessee Titans",
                    SportId = 3

                },

                new Team()
                {
                    TeamId = 4,
                    Name = "Nashville Soccer Club",
                    SportId = 2

                }

            );

            

          

        }
    }
    
    
}
