namespace Gies_Application.Models
{
	public class Trainee
	{
    public virtual ApplicationUser1 ApplicationUser1 { get; set; }
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
  }
}