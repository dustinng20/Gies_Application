using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gies_Application.ViewModels
{
  public class ManagerStaffViewModel
  {
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
    //public int Age { get; set; }
    public int Phone { get; set; }
    public List<ManagerStaffViewModel> Trainee { get; set; }
    public List<ManagerStaffViewModel> Trainer { get; set; }
    public object[] Id { get; internal set; }
  }
}