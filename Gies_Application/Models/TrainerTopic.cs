using System.ComponentModel.DataAnnotations;

namespace Gies_Application.Models
{
  public class TrainerTopic
  {
    [Key]
    public int Id { get; set; }
    public string TrainerId { get; set; }
    public int TopicId { get; set; }
    public ApplicationUser1 Trainer { get; set; }
    public Topic Topic { get; set; }
  }
}