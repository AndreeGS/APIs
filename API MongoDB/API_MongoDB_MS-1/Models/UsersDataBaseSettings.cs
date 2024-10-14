namespace API_MongoDB_MS_1.Models
{
    public class UsersDataBaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DataBaseName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;

    }
}
