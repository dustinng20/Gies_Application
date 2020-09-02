using Gies_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gies_Application.Controllers
{
  public class CategoriesController : Controller
  {
    private ApplicationDbContext1 db = new ApplicationDbContext1();

    // GET: Categories
    [Authorize(Roles ="Staff")]
    public ActionResult Index(string Searching)
    {
      return View(db.Categories.Where(x => x.Name.Contains(Searching) || Searching == null).ToList());
    }

    // GET: Categories/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Category category = db.Categories.Find(id);
      if (category == null)
      {
        return HttpNotFound();
      }
      return View(category);
    }
    [Authorize(Roles = "Staff")]
    // GET: Categories/Create
    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }

    // POST: Categories/Create
    [HttpPost]
    public ActionResult Create(Category category)
    {
      if (ModelState.IsValid)
      {
        if (db.Categories.Any(ac => ac.Name.Equals(category.Name)))
        {
          ModelState.AddModelError("", "There is already one like that");
          return View(category);
        }

        else
        {
          db.Categories.Add(category);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
      }

      return View(category);
    }
    [Authorize(Roles = "Staff")]
    // GET: Categories/Edit/5
    [HttpGet]
    public ActionResult Edit(int id)
    {
      var categoryInDb = db.Categories.SingleOrDefault(p => p.Id == id);
      if (categoryInDb == null)
      {
        return HttpNotFound();
      }
      return View(categoryInDb);
    }

    // POST: Categories/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Category category)
    {
      var categoryInDb = db.Categories.SingleOrDefault(p => p.Id == category.Id);
      if (categoryInDb == null)
      {
        return HttpNotFound();
      }

      categoryInDb.Name = category.Name;
      categoryInDb.Description = category.Description;

      db.SaveChanges();
      return RedirectToAction("Index");
    }
    [Authorize(Roles = "Staff")]
    // GET: Categories/Delete/5
    [HttpGet]
    public ActionResult Delete(int id)
    {
      var categoryInDb = db.Categories.SingleOrDefault(p => p.Id == id);
      if (categoryInDb == null)
      {
        return HttpNotFound();
      }
      db.Categories.Remove(categoryInDb);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}