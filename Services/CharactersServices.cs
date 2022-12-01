using MongoDB.Driver;
using MVC_web.Models;
using System.Numerics;

namespace MVC_web.Services
{
    public class CharactersServices : ICharactersServices
    {

        private readonly IMongoCollection<Characters> _Characters;

        public CharactersServices(IAssessment2DatabaseSetting settings)
        {
            var mongoClient = new MongoClient(settings.ConnectionString/*"mongodb://localhost:27017"*/);
            var database = mongoClient.GetDatabase(settings.DatabaseName/*"Assessment2"*/);
            _Characters = database.GetCollection<Characters>(settings.CharactersCollectionName/*"Characters"*/);
        }

        public Characters Create(Characters character)
        {

            _Characters.InsertOne(character);
            return character;

        }

        public string Delete_with_ID(int id)
        {
            _Characters.DeleteOne(character => character.Id == id);
            return "Deleted";
        }

        public List<Characters> GetAll()
        {
            return _Characters.Find(character => true).ToList();

        }

        public Characters Get_with_ID(int id)
        {
            return _Characters.Find(character => character.Id == id).FirstOrDefault();
        }

        public string Update_with_ID(int id, Characters character)
        {
            _Characters.ReplaceOne(character => character.Id == id, character);
            return ("Player with Id = "+character.Id+ " has been updated");
        }

        public List<Characters> GetSortedPlayTime()
        {
            var character = _Characters.Find(characters => true).ToList();
            var sortedCharacter = character.OrderByDescending(character => character.Playtime).ToList();
            return sortedCharacter;
        }


    }
}
