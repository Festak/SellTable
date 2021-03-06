﻿using SellTables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using SellTables.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SellTables.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersRepository(ApplicationDbContext dataBaseContext)
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dataBaseContext));
        }

        bool IUserRepository.IsInAdminRole(string userId)
        {
            return userManager.IsInRole(userId, "admin");
        }

        IdentityResult IUserRepository.DeleteUser(ApplicationUser user)
        {
            return userManager.Delete(user);
        }

        ApplicationUser IUserRepository.FindUser(string userName)
        {
            return userManager.Users.Include(m => m.Medals).Include(c => c.Creatives).FirstOrDefault(u => u.UserName == userName);
        }

        ApplicationUser IUserRepository.FindUserById(string userId)
        {
            return userManager.Users.Include(m => m.Medals).Include(c => c.Creatives).FirstOrDefault(u => u.Id == userId);
        }

        ICollection<ApplicationUser> IUserRepository.GetAllUsers()
        {
            return userManager.Users.Include(m => m.Medals).Include(c => c.Creatives).ToList();
        }

     ApplicationUser IUserRepository.GetCurrentUser(string name)
        {
            return userManager.Users.Include(m => m.Medals).Include(c => c.Creatives).FirstOrDefault(u=>u.UserName == name); 
        }

        IdentityResult IUserRepository.UpdateUser(ApplicationUser user)
        {
            return userManager.Update(user);
            
        }


    }
}