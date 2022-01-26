﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using FinalRuiz2018.Clasess;
using FinalRuiz2018.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalRuiz2018.Content
{
    public class UserHelper:IDisposable
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static FinalRuiz2018DbContext db = new FinalRuiz2018DbContext();

        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var userASP = userManager.FindByName(email);
            if (userASP == null)
            {
                CreateUserASP(email, "Admin", password);
                return;
            }

            userManager.AddToRole(userASP.Id, "Admin");
        }

        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                userASP = new ApplicationUser
                {
                    Email = email,
                    UserName = email,
                };
                userManager.Create(userASP, email);

            }


            userManager.AddToRole(userASP.Id, roleName);
        }

        public static bool DeleteUser(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return false;
            }

            userManager.RemoveFromRole(userASP.Id, roleName);
            return true;
        }

        public static void CreateUserASP(string email, string roleName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, roleName);
        }

        public static async Task PasswordRecovery(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return;
            }

            var user = db.Usuarios.FirstOrDefault(tp => tp.NombreUsuario == email);
            if (user == null)
            {
                return;
            }

            var random = new Random();
            var newPassword = string.Format("{0}{1}{2:04}*",
                user.Nombres.Trim().ToUpper().Substring(0, 1),
                user.Apellido.Trim().ToLower(),
                random.Next(10000));

            userManager.RemovePassword(userASP.Id);
            userManager.AddPassword(userASP.Id, newPassword);

            var subject = "FinalRuiz2018 Password Recovery";
            var body = string.Format(@"
                <h1>VirtualCommerce Password Recovery</h1>
                <p>Yor new password is: <strong>{0}</strong></p>
                <p>Please change it for one, that you remember easyly",
                newPassword);

            await MailHelper.SendMail(email, subject, body);
        }

        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }

        public static bool UpdateUserName(string currentUserName, string newUserName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userAsp = userManager.FindByEmail(currentUserName);
            if (userAsp == null)
            {
                return false;
            }

            userAsp.UserName = newUserName;
            userAsp.Email = newUserName;
            var response = userManager.Update(userAsp);
            return true;
        }
    }
}