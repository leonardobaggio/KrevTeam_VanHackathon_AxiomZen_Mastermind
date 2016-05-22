using MasterMindApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MasterMindApi.Controllers
{
    public class StageController : ApiController
    {
        // GET api/stage
        public IEnumerable<Stages> Get()
        {
            var context = new MastermindEntities();

            return context.Stages;
        }

        // GET api/stage/5
        public Stages Get(int id)
        {
            var context = new MastermindEntities();

            var stage = context.Stages.Where(x => x.StageId == id).FirstOrDefault();

            context = null;

            return stage;
        }

        // POST api/stage
        public void Post(Stages stage)
        {
            var context = new MastermindEntities();

            context.Stages.Add(stage);
            context.SaveChanges();

            context = null;
        }

        // PUT api/stage/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/stage/5
        public void Delete(int id)
        {
        }

        /**/

        [Route("Api/Stage/WaitPlay")]
        public Stages WaitPlay(Stages stage)
        {
            int PlayerId = (int)stage.UserId;
            int GameId = (int)stage.GameId;

            using (var context = new MastermindEntities())
            {
                Games game = context.FindGame(PlayerId, GameId);

                int Player_Games_StagesId1 = 0;
                int Player_Games_StagesId2 = 0;

                game = context.Games.Where(x => x.GameId == GameId).FirstOrDefault();
                Player_Games_StagesId1 = (int)game.Player_Games_StagesId1;
                Player_Games_StagesId2 = (int)game.Player_Games_StagesId2;

                if (Player_Games_StagesId2 == 0)
                {
                    stage.StageCheck2 = "80";
                }
                else
                {
                    if (PlayerId != Player_Games_StagesId1)
                    {
                        Player_Games_StagesId2 = Player_Games_StagesId1;
                        Player_Games_StagesId1 = PlayerId;
                    }


                    if (context.Stages.Where(x => x.UserId == Player_Games_StagesId1 && x.GameId == GameId).Count() ==
                        context.Stages.Where(x => x.UserId == Player_Games_StagesId2 && x.GameId == GameId).Count())
                    {
                        var a = context.Stages.Where(x => x.UserId == Player_Games_StagesId2 && x.GameId == GameId).ToList();
                        if (a.Count > 0)
                        {
                            int p = a.Max(y => y.StageId);
                            Stages stg = context.Stages.Where(x => x.StageId == p).FirstOrDefault();
                            stage.StageCheck2 = stg.StageCheck;
                        }

                        if (stage.StageCheck2 == null)
                            stage.StageCheck2 = "00";
                        if (stage.StageCheck2.Length == 0)
                            stage.StageCheck2 = "00";
                        
                    }
                    else if (context.Stages.Where(x => x.UserId == Player_Games_StagesId1 && x.GameId == GameId).Count() <
                       context.Stages.Where(x => x.UserId == Player_Games_StagesId2 && x.GameId == GameId).Count())
                    {

                        var a = context.Stages.Where(x => x.UserId == Player_Games_StagesId2 && x.GameId == GameId).ToList();
                        stage.StageCheck2 = "";

                        if (a.Count > 0)
                        {
                            int p = a.Max(y => y.StageId);
                            Stages stg = context.Stages.Where(x => x.StageId == p).FirstOrDefault();
                            stage.StageCheck2 = stg.StageCheck;
                        }
                    }
                    else
                    {
                        stage.StageCheck2 = "";
                    }
                }
            }

            return stage;
        }

        [Route("Api/Stage/AddPlay")]
        public Stages AddPlay(Stages stage)
        {
            using (var context = new MastermindEntities())
            {
                if (WaitPlay(stage).StageCheck2.Length > 0)
                {
                    if (stage.StageCheck2 == "00")
                    {
                        stage.StageCheck2 = "";
                    }
                    stage = context.CheckSequence(stage);
                }
                
            }
            return stage;
        }
    }
}
