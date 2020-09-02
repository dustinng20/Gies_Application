using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gies_Application.Models
{
  public static class CustomRole
  {
    public const string Admin = "Admin";
    public const string Staff = "Staff";
    public const string Trainer = "Trainer";
    public const string Trainee = "Trainee";
    public const string AdminOrStaff = Admin + "," + Staff;
    public const string StaffOrTrainee = Staff + "," + Trainee;
    public const string AdminOrTrainer = Admin + "," + Trainer;
  }
}