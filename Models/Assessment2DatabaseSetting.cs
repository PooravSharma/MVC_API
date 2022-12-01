namespace MVC_web.Models
{
    public class Assessment2DatabaseSetting : IAssessment2DatabaseSetting
    {
        public string PlayersCollectionName { get; set; } = null!;
        public string CharactersCollectionName { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
