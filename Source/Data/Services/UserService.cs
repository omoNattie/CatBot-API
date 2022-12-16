using ServerSide.Source.Models;
using MongoDB.Driver;

namespace ServerSide.Source.Data.Services;

public class UserService 
{
    public IMongoCollection<UserModel> collection { get; set; }

    public UserService()
    {
        MongoClientSettings settings = MongoClientSettings.FromConnectionString(Config.DatabaseConnectionString);
        MongoClient Client = new MongoClient(settings);
        IMongoDatabase Database = Client.GetDatabase(Config.DatabaseName);
        collection = Database.GetCollection<UserModel>(Config.DatabaseCollection);
    }

    public async Task<List<UserModel>> GetAllAsync() =>
        await collection.Find(_ => true).ToListAsync();

    public async Task<UserModel> GetByIdAsync(ulong id) =>
        await collection.Find(u => u.DiscordID == id).FirstOrDefaultAsync();
}