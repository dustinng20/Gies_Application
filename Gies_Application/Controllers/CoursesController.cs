using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Gies_Application.Models;

namespace FPT_Training_System.Controllers
{
  public class CoursesController : Controller
  {
    private ApplicationDbContext1 db = new ApplicationDbContext1();
    [Authorize(Roles = "Staff, Trainee")]
    // GET: Courses
    public ActionResult Index()
    {
      var courses = db.Courses.Include(c => c.Category).Include(c => c.Topic);
      return View(courses.ToList());
    }
    [Authorize(Roles = "Staff")]
    // GET: Courses/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var course = db.Courses.Find(id);
      if (course == null)
      {
        return HttpNotFound();
      }
      return View(course);
    }
    [Authorize(Roles = "Staff")]
    // GET: Courses/Create
    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
      ViewBag.TopicId = new SelectList(db.Topics, "Id", "Name");
      return View();
    }

    // POST: Courses/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Course course)
    {
      if (ModelState.IsValid)
      {
        db.Courses.Add(course);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
      ViewBag.TopicId = new SelectList(db.Topics, "Id", "Name", course.TopicId);
      return View(course);
    }
    
    [Authorize(Roles = "Staff")]
    // GET: Courses/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Course course = db.Courses.Find(id);
      if (course == null)
      {
        return HttpNotFound();
      }
      ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
      ViewBag.TopicId = new SelectList(db.Topics, "Id", "Name", course.TopicId);
      return View(course);
    }

    // POST: Courses/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Course course)
    {
      if (ModelState.IsValid)
      {
        db.Entry(course).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", course.CategoryId);
      ViewBag.TopicId = new SelectList(db.Topics, "Id", "Name", course.TopicId);
      return View(course);
    }
    [Authorize(Roles = "Staff")]
    // GET: Courses/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Course course = db.Courses.Find(id);
      if (course == null)
      {
        return HttpNotFound();
      }
      return View(course);
    }

    // POST: Courses/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Course course = db.Courses.Find(id);
      db.Courses.Remove(course);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
