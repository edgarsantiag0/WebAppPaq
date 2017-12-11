using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebAppPaq.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAppPaq.Data;

namespace WebAppPaq.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {



            IdentityResult roleResult;
            bool adminRoleExists = await _roleManager.RoleExistsAsync("Administrator");
            if (!adminRoleExists)
            {
               // _logger.LogInformation("Adding Admin role");
                roleResult = await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            // Select the user, and then add the admin role to the user
            ApplicationUser user = await _userManager.FindByNameAsync("admin@chikitoexpress.com");
            if (!await _userManager.IsInRoleAsync(user, "Administrator"))
            {
                //_logger.LogInformation("Adding sysadmin to Admin role");
                var userResult = await _userManager.AddToRoleAsync(user, "Administrator");
            }


            //var user = new ApplicationUser();
            //user.UserName = "admin@chikitoexpress.com";
            //user.Email = "admin@chikitoexpress.com";

            //string userPWD = "Admin123456$";

            //var chkUser = await _userManager.CreateAsync(user, userPWD);

            ////Add default User to Role Admin    
            //if (chkUser.Succeeded)
            //{
            //    var result1 = await _userManager.AddToRoleAsync(user, "Administrator");

            //}



            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
