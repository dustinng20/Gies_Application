using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gies_Application.Models
{
	public class CourseCategory
	{
		public int Id { get; set; }
		public string CourseCategoryName { get; set; }
		public string Description { get; set; }
		public ICollection<Course> Courses { get; set; }
	}
}