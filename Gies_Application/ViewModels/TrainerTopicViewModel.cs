using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gies_Application.Models;

namespace Gies_Application.ViewModels
{
  public class TrainerTopicViewModel
  {
    public TrainerTopic TrainerTopic { get; set; }
    public IEnumerable<ApplicationUser1> Trainers { get; set; }
    public IEnumerable<Topic> Topics { get; set; }
  }
}