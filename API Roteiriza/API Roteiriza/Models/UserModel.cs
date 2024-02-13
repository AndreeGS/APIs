using API_Roteiriza.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Roteiriza.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public CardTravelModel? CardTravel { get; set; }

    }
}
