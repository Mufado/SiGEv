using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SiGEv.Models.Enums.Enums;

namespace SiGEv.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        public string Title { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        
        [Display(Name = "Data e Horario")]
        public DateTime Date { get; set; }

        [Display(Name = "Tipo")]
        public EventType Type { get; set; }

        [ForeignKey("Venue")]
		[Display(Name = "Endereço")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public Event()
        {
        }

        public Event(int id, string title, DateTime date, EventType type, int venueId, Venue venue)
        {
            Id = id;
            Title = title;
            Date = date;
            Type = type;
            VenueId = venueId;
            Venue = venue;
        }
    }
}
