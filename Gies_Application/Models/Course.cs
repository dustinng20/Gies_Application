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
		public Course()
		{
			this.TraineeInfoes = new HashSet<TraineeInfo>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public ICollection<Topic> Topics { get; set; }
		[Display(Name = "Trainees")]
		public ICollection<TraineeInfo> TraineeInfoes { get; set; }

		public CourseCategory CourseCategory { get; set; }
	}
}