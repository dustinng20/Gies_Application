using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gies_Application.Models
{
	public class Course
	{
    [Display(Name = "Number")]
    public int Id { get; set; }
    [Required]
    [Display(Name = "Course Name")]
    public string Topic { get; set; }
    public int Credits { get; set; }
    public virtual ICollection<Enrollment> Enrollments { get; set; }
  }
}