using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiGEv.Models
{
    public class Section
    {
        public int Id { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double CommonPrice { get; set; }

        public Section()
        {
        }

        public Section(int id, int eventId, Event @event, TimeSpan startTime, TimeSpan endTime, double commonPrice)
        {
            Id = id;
            EventId = eventId;
            Event = @event;
            StartTime = startTime;
            EndTime = endTime;
            CommonPrice = commonPrice;
        }
    }
}
