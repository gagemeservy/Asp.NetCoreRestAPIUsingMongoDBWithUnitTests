using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OneIdentityAPI.Models;

    public class Address
    {
        public string? street { get; set; }
        public string? suite { get; set; }
        public string? city { get; set; }
        public string? zipcode { get; set; }
        public Geo? geo { get; set; }
    }

    public class Company
    {
        public string? name { get; set; }
        public string? catchPhrase { get; set; }
        public string? bs { get; set; }
    }

    public class Geo
    {
        public string? lat { get; set; }
        public string? lng { get; set; }
    }

    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? DbId {get; set;}
        public int id { get; set; }
        public required string name { get; set; }
        public required string username { get; set; }
        public required string email { get; set; }
        public Address? address { get; set; }
        public required string phone { get; set; }
        public required string website { get; set; }
        public Company? company { get; set; }
    }


