using Gies_Application.Models;
using Gies_Application.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Gies_Application.Controllers
{
	public class ManagerStaffViewModelsController : Controller
	{
		ApplicationDbContext1 _context;
		public ManagerStaffViewModelsController()
		{
			_context = new ApplicationDbContext1();
		}
		// GET: ManagerStaffViewModels
		public ActionResult Index()
		{
			var role = (from r in _context.Roles where r.Name.Contains("Trainee") select r).FirstOrDefault();
			var users = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

			var userVM = users.Select(user => new ManagerStaffViewModel
			{
				UserName = user.UserName,
				Email = user.Email,
				RoleName = "Trainee",
				UserId = user.Id
			}).ToList();


			var role2 = (from r in _context.Roles where r.Name.Contains("Trainer") select r).FirstOrDefault();
			var admins = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role2.Id)).ToList();

			var adminVM = admins.Select(user => new ManagerStaffViewModel
			{
				UserName = user.UserName,
				Email = user.Email,
				RoleName = "Trainer",
				UserId = user.Id
			}).ToList();

			var role3 = (from r in _context.Roles where r.Name.Contains("Staff") select r).FirstOrDefault();
			var staff = _context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role3.Id)).ToList();

			var staffVM = staff.Select(user => new ManagerStaffViewModel
			{
				UserName = user.UserName,
				Email = user.Email,
				RoleName = "Staff",
				UserId = user.Id
			}).ToList();


			var model = new ManagerStaffViewModel { Trainee = userVM, Trainer = adminVM, Staff = staffVM };
			return View(model);
		}
	}
}