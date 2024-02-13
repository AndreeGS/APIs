using System.ComponentModel.DataAnnotations;

namespace API_Roteiriza.Models
{
    public class CostModel
    {
        [Key]
        public int CostId { get; set; }
        public int TravelId { get; set; }
        public string CostName { get; set; }
        public double Cost {  get; set; }
    }
}
