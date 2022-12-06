using MVC_web.Models;

namespace MVC_web.Services
{
    public interface IPlayersServices
    {
        List<Players> GetAll();
        Players Get_with_ID(int id);
        Players Create(Players player);

        string Update_with_ID(int id, Players player);

        string Delete_with_ID(int id);

        string TopRank();

        List<Players> Get_Player_Rank();
        List<Players> Get_Charactertime_Primary();
        List<Players> Get_Charactertime_Secondary();
        void PlayerRanker(Players player);

        string Update_Multiple(Players player);
    
    }
}
