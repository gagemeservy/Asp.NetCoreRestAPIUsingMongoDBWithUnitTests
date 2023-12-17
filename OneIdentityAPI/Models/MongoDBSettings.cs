namespace OneIdentityAPI.Models;

public class MongoDBSettings 
{
    public string ConnectionURI {get; set; } = null!;
    public string DbName {get; set; } = null!;
    public string CollectionName {get; set; } = null!;

}