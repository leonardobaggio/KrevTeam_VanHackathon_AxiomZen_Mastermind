using MasterMindApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasterMindApi.Controllers
{
    public class GameStageController : ApiController
    {
        // GET api/gamestage
        public IEnumerable<Games_Stages> Get()
        {
            var context = new MastermindEntities();

            return context.Games_Stages;
        }

        // GET api/gamestage/5
        public Games_Stages Get(int id)
        {
            var context = new MastermindEntities();

            var game_stage = context.Games_Stages.Where(x => x.Games_StagesId == id).FirstOrDefault();

            context = null;

            return game_stage;
        }

        // POST api/gamestage
        public void Post(Games_Stages game_stage)
        {
            var context = new MastermindEntities();

            context.Games_Stages.Add(game_stage);
            context.SaveChanges();

            context = null;
        }

        // PUT api/gamestage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/gamestage/5
        public void Delete(int id)
        {
        }
    }
}
