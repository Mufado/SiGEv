using System.ComponentModel.DataAnnotations;

namespace SiGEv.Models
{
    public class Venue
    {
        public int Id { get; set; }

		[Display(Name = "Quantidade de Assentos")]
		public int TotalSeats { get; set; }

        [Display(Name = "Endereço")]
        public string Adress { get; set; }
		[Display(Name = "Descrição")]
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
