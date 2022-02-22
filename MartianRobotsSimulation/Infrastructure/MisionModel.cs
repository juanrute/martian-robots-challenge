using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class MisionModel
    {
        public int Id { get; set; }
        public int RobotsQuantity { get; set; }
        public string Surface { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<RobotOutputModel> RobotsResult { get; set; }
        public ICollection<RobotCommadModel> RobotsCommands { get; set; }
    }
}
