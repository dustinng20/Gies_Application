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
    public int Id { get; set; }
		public string CourseId { get; set; }
		[Required]
    [DisplayName("Course Name")]
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int TopicId { get; set; }
    public Topic Topic { get; set; }
  }
}