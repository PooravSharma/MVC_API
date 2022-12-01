using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MVC_web.Models
{
    [BsonIgnoreExtraElements]
    public class Players
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("rank")]
        public int Rank { get; set; }

        [BsonElement("Primary_Character")]
        public string? Primary_Character { get; set; } = string.Empty;

        [BsonElement("Primary_Character_Play_Time")]
        public int? Primary_Character_PlayTime { get; set; }

        [BsonElement("Secondary_Character")]
        public string? Secondary_Character { get; set; } = string.Empty;

        [BsonElement("Secondary_Character_Play_Time")]
        public int? Secondary_Character_PlayTime { get; set; }



    }
}