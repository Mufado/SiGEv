using System;

namespace SiGEv.Models
{
    public class Section
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double CommonPrice { get; set; }
    }
}
