﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Svbase.Core.Data;
using Svbase.Core.Data.Entities;
using Svbase.Core.Consts;

namespace Svbase.Core.Migrations.DbInitializer
{
    public class CreateIfNotExistWithSeed
    {
        private const string UserPassword = "Adm!nSvBase";
        private const string EmailDomain = "@svbase.com";
        private const string AdminLastName = "Admin";
        private const string UserLastName = "User";


        private static readonly string[] Admins =
        {
            AdminLastName
        };

        private static readonly string[] Users =
        {
            UserLastName
        };

        private static readonly string[][] Profiles =
        {
            new [] {"Admin", AdminLastName},
            new [] {"User", UserLastName }
        };

        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateIfNotExistWithSeed(ApplicationDbContext context)
        {
            _dbContext = context;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }

        public void InitializeDb()
        {
            if (!_dbContext.Roles.Any())
            {
                InitUserAndRoles();
            }
        }

        private void InitUserAndRoles()
        {
            var roleResult = InitRoles();
            roleResult.ContinueWith(x => InitUsers());
        }

        private async Task InitRoles()
        {
            var roles = RoleConsts.GetAllRoles();
            foreach (var roleName in roles)
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
            await _dbContext.SaveChangesAsync();
        }

        private async void InitUsers()
        {
            foreach (var profile in Profiles)
            {
                var email = profile[1] + EmailDomain;
                var user = new ApplicationUser
                {
                    FirstName = profile[0],
                    LastName = profile[1],
                    Email = email,
                    UserName = email,
                    EmailConfirmed = true,
                };

                await _userManager.CreateAsync(user, UserPassword);
                await _dbContext.SaveChangesAsync();

                if (Admins.Contains(user.LastName))
                {
                    await _userManager.AddToRoleAsync(user.Id, RoleConsts.Admin);
                }
                else if (Users.Contains(user.LastName))
                {
                    await _userManager.AddToRoleAsync(user.Id, RoleConsts.User);
                }
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
