using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Gies_Application.Models
{
	public class ApplicationUser1 : IdentityUser
	{
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync
      (UserManager<ApplicationUser1> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Phone { get; set; }
    //public string WorkingPlace { get; set; }
  }
}