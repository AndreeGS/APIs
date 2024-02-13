using System.ComponentModel.DataAnnotations;

namespace API_Roteiriza.Models
{
    public class CheckList
    {
        [Key]
        public int CheckListId { get; set; }
        public int TravelId { get; set; }
        public string CheckListName { get; set; }

        public string[]? ItemList { get; set; }
    }
}
