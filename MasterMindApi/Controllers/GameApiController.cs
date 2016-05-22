using MasterMindApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasterMindApi.Controllers
{
    public class GameApiController : ApiController
    {
        // GET api/game
        public IEnumerable<Games> Get()
        {
            var context = new MastermindEntities();

            return context.Games;
        }

        // GET api/game/5
        public Games Get(int id)
        {
            var context = new MastermindEntities();

            var game = context.Games.Where(x => x.GameId == id).FirstOrDefault();

            context = null;

            return game;
        }

        // POST api/game
        public void Post(Games game)
        {
            var context = new MastermindEntities();

            context.Games.Add(game);
            context.SaveChanges();

            context = null;
        }

        // PUT api/game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/game/5
        public void Delete(int id)
        {
        }

        [Route("Api/GameApi/NewGame")]
        public Games NewGame(Users Player)
        {
            using (var context = new MastermindEntities())
            {
                Games game;

                if ((bool)Player.IsWaitChallenger)
                {
                    game = context.FindGame(Player.UserId, 0);

                    if (game == null)
                    {
                        game = context.CreateGame(Player);
                    }
                }
                else
                {
                    game = context.CreateGame(Player);
                }

                return game;
            }
        }

        [Route("Api/GameApi/WaitUser")]
        public bool WaitUser(Games game)
        {
            using (var context = new MastermindEntities())
            {
                game = context.FindGame((int)game.Player_Games_StagesId1, (int)game.GameId);

                if (game.Player_Games_StagesId2 == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
