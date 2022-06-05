using System;
using System.Collections.Generic;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Section> Sections { get; set; }
        public DateTime Date { get; set; }
        public EventType Type { get; set; }
        public Venue Venue { get; set; }
    }
}
