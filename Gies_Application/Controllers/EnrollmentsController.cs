using Gies_Application.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Gies_Application.ViewModels;
namespace Gies_Application.Controllers
{
	public class EnrollmentsController : Controller
	{
		// GET: Enrollments
		private readonly ApplicationDbContext1 _context;
		public EnrollmentsController()
		{
			_context = new ApplicationDbContext1();
		}
		// GET: Movies
		//	[Authorize]
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();
			var enrollments = _context.Enrollments
				.Include(e => e.TraineeId)
				.Include(e => e.CourseCategory)
				.Include(e => e.Course)
				.ToList();
			return View(enrollments);
		}
		[HttpGet]
		//	[Authorize(Roles = "Admin")]
		public ActionResult Create()
		{
			var viewModel = new EnrollmentViewModel()
			{
				Trainee = _context.Trainees.ToList(),
				CourseCategories = _context.CourseCategories.ToList(),
				Courses = _context.Courses.ToList()
			};
			return View(viewModel);
		}
		[ValidateAntiForgeryToken]
		[HttpPost]
		//	[Authorize(Roles = "Admin")]
		public ActionResult Create(Enrollment enrollment)
		{
			_context.Enrollments.Add(enrollment);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id)
		{
			var EnrollmentInDb = _context.Enrollments.SingleOrDefault(m => m.Id == id);
			if (EnrollmentInDb == null) return HttpNotFound();
			_context.Enrollments.Remove(EnrollmentInDb);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			var EnrollmentInDb = _context.Enrollments.SingleOrDefault(m => m.Id == id);
			if (EnrollmentInDb == null) return HttpNotFound();
			var viewModel = new EnrollmentViewModel()
			{
				Trainee = _context.Trainees.ToList(),
				CourseCategories = _context.CourseCategories.ToList(),
				Courses = _context.Courses.ToList(),
				Enrollment = EnrollmentInDb
			};
			return View(viewModel);
		}
		[HttpPost]
		public ActionResult Edit(Enrollment enrollment)
		{
			var EnrollmentInDb = _context.Enrollments.SingleOrDefault(m => m.Id == enrollment.Id);
			EnrollmentInDb.TraineeId = enrollment.TraineeId;
			EnrollmentInDb.CourseCategoryId = enrollment.CourseCategoryId;
			EnrollmentInDb.CourseId = enrollment.CourseId;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}