using API_MongoDB_MS_1.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
namespace API_MongoDB_MS_1.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _usersCollection;
        public UserService(
            IOptions<UsersDataBaseSettings> UserDataBaseSettings)
        {
            var mongoClient = new MongoClient(
                UserDataBaseSettings.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(
                UserDataBaseSettings.Value.DataBaseName);
            _usersCollection = mongoDataBase.GetCollection<User>(
                UserDataBaseSettings.Value.UsersCollectionName);
        }
        //CRUD
        public async Task<List<User>> ReadAllUsers()
        {
            var users = await _usersCollection.Find(_ => true).ToListAsync();
            return users;
        }
        public async Task<User> ReadUserById(string id)
        {
            var user = await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return user;
        }
        public async Task<User> CreateUser(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return user;
        }
        public async Task<bool> UpdateUser(string id, User userUpdate)
        {
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, userUpdate);
            return true;
        }
        public async Task<bool> DeleteUser(string id)
        {
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }
    }
}

