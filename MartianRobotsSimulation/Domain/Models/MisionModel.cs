using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MisionModel
    {
        public int Id { get; set; }
        public int RobotsQuantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string RobotsResult { get; set; }
        public string RobotsInputs { get; set; }
    }
}
