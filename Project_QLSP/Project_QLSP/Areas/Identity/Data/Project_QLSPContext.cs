using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_QLSP.Areas.Identity.Data;

namespace Project_QLSP.Data
{
    public class Project_QLSPContext : IdentityDbContext<Project_QLSPUser>
    {
        public Project_QLSPContext(DbContextOptions<Project_QLSPContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            this.SeedRoles(builder);
            this.SeedUser(builder);
            this.SeedUserToRole(builder);
        }

        // Tạo Roles
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole()
                    {
                        Id = "fab4fac1-c546-41de-aebc-a14da6895711", // set GUI vào để tiến hành tạo
                        Name = "Admin",
                        //ConcurrencyStamp = "1", // Chống conflict khi ghi dữ liệu
                        NormalizedName = "Admin"
                    }
                );
        }

        private void SeedUser(ModelBuilder builder)
        {
            Project_QLSPUser user = new Project_QLSPUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                NormalizedUserName = "admin@gmail.com",

                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "0963256951",

                SecurityStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<Project_QLSPUser> pHash = new PasswordHasher<Project_QLSPUser>(); // Hash password
            
            user.PasswordHash = pHash.HashPassword(user, "Admin#123");
            user.EmailConfirmed = true;
            builder.Entity<Project_QLSPUser>().HasData(user);
        }

        // Gán user vào Role
        private void SeedUserToRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>()
            {
                RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
            }
                );
        }

    }
}
