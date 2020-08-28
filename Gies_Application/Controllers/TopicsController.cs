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

    // GET: Topics
    public ActionResult Index()
    {
      return View(db.Topics.ToList());
    }

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
        db.Topics.Add(topic);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(topic);
    }

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