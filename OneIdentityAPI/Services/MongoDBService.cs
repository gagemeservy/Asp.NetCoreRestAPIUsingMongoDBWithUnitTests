using OneIdentityAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace OneIdentityAPI.Services;

public class MongoDBService 
{
    private readonly IMongoCollection<User> _usersCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
       var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDBSettings.Value.DbName);
        _usersCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
        
        //var client = new MongoClient("mongodb+srv://gage:mongodb@cluster0.rwtzavj.mongodb.net/?retryWrites=true&w=majority");
        //var database = client.GetDatabase("userdb");
        //_usersCollection = database.GetCollection<User>("users");
    }

    /*public MongoDBService(MongoDBSettings mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.ConnectionURI.ToString());
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.DbName.ToString());
        _usersCollection = database.GetCollection<User>(mongoDBSettings.CollectionName.ToString());
    }*/

    public async Task<List<User>> GetAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetDBIDAsync(string id) =>
        await _usersCollection.Find(x => x.DbId == id).FirstOrDefaultAsync();

    public async Task<User?> GetUserIDAsync(int id) =>
        await _usersCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.DbId == id, updatedUser);
    
    public async Task UpdateByUserIDAsync(int id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.DbId == id);

    public async Task RemoveUserIDAsync(int id) =>
        await _usersCollection.DeleteOneAsync(x => x.id == id);
}