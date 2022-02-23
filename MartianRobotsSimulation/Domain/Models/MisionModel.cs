using System;

namespace Domain.Models
{
    public class MisionModel
    {
        public int Id { get; set; }
        public string Surface { get; set; }
        public int RobotsQuantity { get; set; }
        public DateTime ExecutionDateTime { get; set; } = DateTime.Now;
        public string RobotsInputs { get; set; }
        public string RobotsResult { get; set; }
        public string Scents { get; set; }
    }
}
