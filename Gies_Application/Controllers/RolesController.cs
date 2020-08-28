﻿using Gies_Application.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Gies_Application.Controllers
{
  public class RolesController : Controller
  {
    ApplicationDbContext context;
    public RolesController()
    {
      context = new ApplicationDbContext();
    }
    // GET: Roles
    public ActionResult Index()
    {
      if (User.Identity.IsAuthenticated)
      {


        if (!isAdminUser())
        {
          return RedirectToAction("Index", "Home");
        }
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }

      var Roles = context.Roles.ToList();
      return View(Roles);
    }

    public Boolean isAdminUser()
    {
      if (User.Identity.IsAuthenticated)
      {
        var user = User.Identity;
        ApplicationDbContext context = new ApplicationDbContext();
        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
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