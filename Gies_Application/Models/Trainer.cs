using System.ComponentModel.DataAnnotations;

namespace Gies_Application.Models
{
	public class Trainer
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    public string WorkingPlace { get; set; }
    public string PhoneNumber { get; set; }
    public Topic topId { get; set; }
    public Topic Topic { get; set; }
  }
}