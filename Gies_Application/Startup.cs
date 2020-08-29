using Gies_Application.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gies_Application.Startup))]
namespace Gies_Application
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
      createRolesandUsers();
    }

    private void createRolesandUsers()
    {
      ApplicationDbContext1 context = new ApplicationDbContext1();

      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var UserManager = new UserManager<ApplicationUser1>(new UserStore<ApplicationUser1>(context));


      // In Startup iam creating first Admin Role and creating a default Admin User     
      if (!roleManager.RoleExists("Admin"))
      {

        // first we create Admin role    
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Admin";
        roleManager.Create(role);
      }

      var user = new ApplicationUser1();
      user.UserName = "Admin";
      user.Email = "admin@gmail.com";

      string userPassword = "Abc123";

      var checkUser = UserManager.Create(user, userPassword);
      if (checkUser.Succeeded)
      {
        var result1 = UserManager.AddToRole(user.Id, "Admin");
      }


      // creating Creating TrainingStaff role     
      if (!roleManager.RoleExists("Staff"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Staff";
        roleManager.Create(role);

      }

      // creating Creating Trainer role     
      if (!roleManager.RoleExists("Trainer"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Trainer";
        roleManager.Create(role);

      }
      // creating Creating Trainee role     
      if (!roleManager.RoleExists("Trainee"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Trainee";
        roleManager.Create(role);

      }
    }
  }
}
