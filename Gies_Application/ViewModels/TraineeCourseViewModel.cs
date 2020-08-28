using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gies_Application.Models;

namespace Gies_Application.ViewModels
{
  public class TraineeCourseViewModel
  {
    public TraineeCourse TraineeCourse { get; set; }
    public IEnumerable<ApplicationUser1> Trainees { get; set; }
    public IEnumerable<Course> Courses { get; set; }
  }
}