using System.ComponentModel.DataAnnotations;

namespace SiGEv.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public int TotalSeats { get; set; }

        [Display(Name = "Endereço")]
        public string Adress { get; set; }
        public string Description { get; set; }

        public Venue()
        {
        }

        public Venue(int id, int totalSeats, string adress, string description)
        {
            Id = id;
            TotalSeats = totalSeats;
            Adress = adress;
            Description = description;
        }
    }
}
