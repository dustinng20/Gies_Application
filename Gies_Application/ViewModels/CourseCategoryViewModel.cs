using System;
using System.Collections.Generic;
using Gies_Application.Models;


namespace Gies_Application.ViewModels
{
  public class CourseCategoryViewModel
  {
    public Course Course { get; set; }
    public IEnumerable<Category> Categories { get; set; }

  }
}