using System;
using System.Collections.Generic;
using Gies_Application.Models;

namespace Gies_Application.ViewModels
{
  public class EnrollmentViewModel
  {
    public Enrollment Enrollment { get; set; }
    public IEnumerable<Trainee> Trainee { get; set; }
    public IEnumerable<CourseCategory> CourseCategories { get; set; }
    public IEnumerable<Course> Courses { get; set; }
  }
}