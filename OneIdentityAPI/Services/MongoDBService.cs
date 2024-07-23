using OneIdentityAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace OneIdentityAPI.Services;

public interface IMongoDBService
{
    Task<List<Users>> GetAsync();
    Task<Users?> GetDBIDAsync();
    Task<Users?> GetUserIDAsync();
    Task CreateAsync();
    Task UpdateAsync();
    Task UpdateByUserIDAsync();
    Task RemoveAsync();
    Task RemoveUserIDAsync();
    
}
public class MongoDBService 
{
    private readonly IMongoCollection<Users> _usersCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
       var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDBSettings.Value.DbName);
        _usersCollection = database.GetCollection<Users>(mongoDBSettings.Value.CollectionName);
    }

    public async Task<List<Users>> GetAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<Users?> GetDBIDAsync(string id) =>
        await _usersCollection.Find(x => x.DbId == id).FirstOrDefaultAsync();

    public async Task<Users?> GetUserIDAsync(int id) =>
        await _usersCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Users newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, Users updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.DbId == id, updatedUser);
    
    public async Task UpdateByUserIDAsync(int id, Users updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.DbId == id);

    public async Task RemoveUserIDAsync(int id) =>
        await _usersCollection.DeleteOneAsync(x => x.id == id);
}