using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gies_Application.Models;

namespace Gies_Application.Controllers
{
  public class TopicsController : Controller
  {
    private ApplicationDbContext1 db = new ApplicationDbContext1();
    [Authorize(Roles = "Staff")]
    // GET: Topics
    public ActionResult Index(string Searching)
    {
      return View(db.Topics.Where(x => x.Name.Contains(Searching) || Searching == null).ToList());
    }
    [Authorize(Roles = "Staff")]
    // GET: Topics/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Topic topic = db.Topics.Find(id);
      if (topic == null)
      {
        return HttpNotFound();
      }
      return View(topic);
    }
    [Authorize(Roles = "Staff")]
    // GET: Topics/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Topics/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Topic topic)
    {
      if (ModelState.IsValid)
      {
        if (db.Topics.Any(ac => ac.Name.Equals(topic.Name)))
        {
          ModelState.AddModelError("", "There is already one like that");
          return View(topic);
        }

        else
        {
          db.Topics.Add(topic);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
      }

      return View(topic);
    }
    [Authorize(Roles = "Staff")]
    // GET: Topics/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Topic topic = db.Topics.Find(id);
      if (topic == null)
      {
        return HttpNotFound();
      }
      return View(topic);
    }

    // POST: Topics/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Topic topic)
    {
      if (ModelState.IsValid)
      {
        db.Entry(topic).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(topic);
    }
    [Authorize(Roles = "Staff")]
    // GET: Topics/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Topic topic = db.Topics.Find(id);
      if (topic == null)
      {
        return HttpNotFound();
      }
      return View(topic);
    }

    // POST: Topics/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Topic topic = db.Topics.Find(id);
      db.Topics.Remove(topic);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}