using Microsoft.EntityFrameworkCore;
using API_Roteiriza.Models;

namespace API_Roteiriza.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UserModel> Usuarios { get; set; }

        public DbSet<CardTravelModel> CardTravel { get; set; }

        public DbSet<CostModel> Cost { get; set; }

        public DbSet<CheckList> CheckLists { get; set; }
    }
}
