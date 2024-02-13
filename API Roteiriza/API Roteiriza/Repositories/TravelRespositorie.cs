using API_Roteiriza.Data;
using API_Roteiriza.Models;

namespace API_Roteiriza.Repositories
{
    public class TravelRespositorie
    {
        private readonly DataContext _context;

        public TravelRespositorie (DataContext context)
        {
            _context = context;
        }
    
    }
}
