using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Roteiriza.Models
{
    public class CardTravelModel 
    {
        public int UserId { get; set; }

        [Key]
        public int TravelId { get; set; }

        [Required]
        public string TravelName { get; set; }  

        public string? TravelDescriptiion { get; set; }

        public DateTime? TravelInitialDate { get; set; }

        public DateTime? TravelFinalDate { get; set; }

        public CostModel? TravelCost { get; set; }

        public CheckList? CheckList { get; set; }

    }
}
