using Gies_Application.Models;
using Gies_Application.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gies_Application.Controllers
{
  public class TraineeCoursesController : Controller
  {
    private ApplicationDbContext1 _context;

    public TraineeCoursesController()
    {
      _context = new ApplicationDbContext1();
    }

    public ActionResult Index()
    {
      if (User.IsInRole("Staff"))
      {
        var traineecourses = _context.TraineeCourses.Include(t => t.Course).Include(t => t.Trainee).ToList();
        return View(traineecourses);
      }
      if (User.IsInRole("Trainee"))
      {
        var traineeId = User.Identity.GetUserId();
        var Res = _context.TraineeCourses.Where(e => e.TraineeId == traineeId).Include(t => t.Course).ToList();
        return View(Res);
      }
      return View("Login");
    }

    public ActionResult Create()
    {
      //get trainer
      var role = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
      var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

      //get topic

      var courses = _context.Courses.ToList();

      var TrainerTopicVM = new TraineeCourseViewModel()
      {
        Courses = courses,
        Trainees = users,
        TraineeCourse = new TraineeCourse()
      };

      return View(TrainerTopicVM);
    }

    [HttpPost]
    public ActionResult Create(TraineeCourseViewModel model)
    {
      //get trainer
      var role = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
      var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

      //get topic

      var courses = _context.Courses.ToList();


      if (ModelState.IsValid)
      {
        _context.TraineeCourses.Add(model.TraineeCourse);
        _context.SaveChanges();
        return RedirectToAction("Index");
      }

      var TrainerTopicVM = new TraineeCourseViewModel()
      {
        Courses = courses,
        Trainees = users,
        TraineeCourse = new TraineeCourse()
      };

      return View(TrainerTopicVM);
    }
  }
}