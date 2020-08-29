using Gies_Application.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web.Mvc;

namespace Gies_Application.Controllers
{
  public class UsersController : Controller
  {
    [Authorize]
    // GET: Users
    public ActionResult Index()
    {
      if (User.Identity.IsAuthenticated)
      {
        var user = User.Identity;
        ViewBag.Name = user.Name;

        ViewBag.displayMenu = "No";

        if (isAdminUser())
        {
          ViewBag.displayMenu = "Yes";
        }
        return View();
      }
      else
      {
        ViewBag.Name = "Not Logged IN";
      }
      return View();
    }

    public Boolean isAdminUser()
    {
      if (User.Identity.IsAuthenticated)
      {
        var user = User.Identity;
        ApplicationDbContext1 context = new ApplicationDbContext1();
        var UserManager = new UserManager<ApplicationUser1>(new UserStore<ApplicationUser1>(context));
        var s = UserManager.GetRoles(user.GetUserId());
        if (s[0].ToString() == "Admin")
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      return false;
    }
  }
}