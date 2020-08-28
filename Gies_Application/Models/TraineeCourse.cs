using System.ComponentModel.DataAnnotations;

namespace Gies_Application.Models
{
	public class TraineeCourse
  {
    [Key]
    public int Id { get; set; }
    public string TraineeId { get; set; }
    public int CourseId { get; set; }
    public ApplicationUser1 Trainee { get; set; }
    public Course Course { get; set; }
  }
}