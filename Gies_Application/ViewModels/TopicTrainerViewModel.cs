using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gies_Application.Models;

namespace Gies_Application.ViewModels
{
  public class TopicTrainerViewModel
  {
    public Trainer Trainer { get; set; }
    public IEnumerable<Topic> topics { get; set; }
  }
}