using Microsoft.AspNetCore.Mvc;
using MVC_web.Models;
using MVC_web.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayersServices playersServices;
        private readonly ICharactersServices characterServices;
        public PlayerController(IPlayersServices playersServices, ICharactersServices characterServices)
        {
            this.playersServices=playersServices;
            this.characterServices=characterServices;
        }


        // GET: api/<PlayerController>
        [HttpGet("Get all Players")]
        public ActionResult<List<Players>> GetAll()
        {
            return playersServices.GetAll();
        }

        // GET api/<PlayerController>/5
        [HttpGet("Get specific Player using {id}")]
        public ActionResult<Players> Get(int id)
        {
            var player = playersServices.Get_with_ID(id);
            if (player == null)
            {
                return NotFound($"Player with the ID = {id} not found");
            }
            playersServices.TopRank(player);
            return player;

        }
        [HttpGet("Get Players in accending rank order")]
        public ActionResult<List<Players>> Player_Rank_Sorted()
        {
            return playersServices.Get_Player_Rank();
        }


        // POST api/<PlayerController>
        [HttpPost("Add a Player")]
        public ActionResult<Players> Post([FromBody] Players players)
        {
            Players existingPlayer = playersServices.Get_with_ID(players.Id);
            List<Characters> characterList = characterServices.GetAll();
            Characters characterName = characterList.Find((character => character.Name == players.Primary_Character));
            Characters characterName2 = characterList.Find((character => character.Name == players.Secondary_Character));
            if (existingPlayer != null)
            {
                return NotFound($"Players with the id = " +players.Id+ " already exists");
            }

            if (players.Rank.Equals(0))
            {
                return NotFound($"Players with rank = 0 cannot be made");
            }
            if (characterName is null)
            {
                return NotFound($"That Character does not exist");
            }
            if (characterName2 is null)
            {
                return NotFound($"That Character does not exist");
            }
            playersServices.Create(players);
            playersServices.TopRank(players);
            playersServices.PlayerRanker(players);
            return CreatedAtAction(nameof(Get), new { id = players.Id }, players);





        }

        // PUT api/<PlayerController>/5
        [HttpPut("Update using {id}")]
        public ActionResult Put(int id, [FromBody] Players players)
        {
            var existingPlayer = playersServices.Get_with_ID(id);
            List<Characters> characterList = characterServices.GetAll();
            Characters characterName = characterList.Find((character => character.Name == players.Primary_Character));
            Characters characterName2 = characterList.Find((character => character.Name == players.Secondary_Character));
            if (existingPlayer == null)
            {
                return NotFound($"Players with Id = {id} not found");
            }
            if (existingPlayer.Rank.Equals(0))
            {
                return NotFound($"Players with rank = 0 cannot be made");
            }
            if (characterName is null)
            {
                return NotFound($"That Character does not exist");
            }
            if (characterName2 is null)
            {
                return NotFound($"That Character does not exist");
            }

            playersServices.Update_with_ID(id, players);
            playersServices.TopRank(players);
            playersServices.PlayerRanker(players);
            return NoContent();
        }


        // DELETE api/<PlayerController>/5
        [HttpDelete("Delete using {id}")]
        public ActionResult Delete(int id)
        {
            var player = playersServices.Get_with_ID(id);
            if (player == null)
            {
                return NotFound($"Players with Id = {id} not found");
            }

            playersServices.Delete_with_ID(player.Id);

            return Ok($"Player with Id = {id} deleted");
        }

        [HttpPut("Update multiple Players")]
        public ActionResult<Players> Put_Many([FromBody] Players[] playerList)
        {
            foreach (var players in playerList)
            {
                List<Characters> characterList = characterServices.GetAll();
                Characters characterName = characterList.Find((character => character.Name == players.Primary_Character));
                Characters characterName2 = characterList.Find((character => character.Name == players.Secondary_Character));
                if (players == null)
                {
                    return NotFound($"Players not found");
                }
                if (players.Rank.Equals(0))
                {
                    return NotFound($"Players with rank = 0 cannot be made");
                }
                if (characterName is null)
                {
                    return NotFound($"That Character does not exist");
                }
                if (characterName2 is null)
                {
                    return NotFound($"That Character does not exist");
                }
                playersServices.Update_Multiple(players);
                playersServices.TopRank(players);
                playersServices.PlayerRanker(players);
                // return Ok("Player with the Id = "+ player.Id +" has been updated");
            }
            return NoContent();

        }

        [HttpGet("Sort by Primary Character Play time")]
        public ActionResult<List<Players>> CharacterPlaytime_Primary()
        {
            return playersServices.Get_Charactertime_Primary();
        }
        [HttpGet("Sort by Secondary Character Play time")]
        public ActionResult<List<Players>> CharacterPlaytime_Secondary()
        {
            return playersServices.Get_Charactertime_Secondary();
        }

    }
}
