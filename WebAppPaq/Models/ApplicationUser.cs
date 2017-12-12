using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace WebAppPaq.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public DateTime Birthdate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string IsAdmin { get; set; }
    }

    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            //Putting our Property to Claims
            //I'm using ClaimType.Email, but you may use any other or your own
            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
        new Claim(ClaimTypes.Email, user.IsAdmin)});

            return principal;
        }
    }

    public static class MyUserPrincipalExtension
    {
        public static string IsAdmin(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(v => v.Type == ClaimTypes.Email).Value;
            }

            return "";
        }
    }
}
