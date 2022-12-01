using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MVC_web.Models
{
    [BsonIgnoreExtraElements]
    public class Characters
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("class")]
        public string Class { get; set; } = string.Empty;

        [BsonElement("playtime")]
        public int Playtime { get; set; }


        [BsonElement("avatar")]
        public string? Avatar { get; set; } = string.Empty;



    }
}
