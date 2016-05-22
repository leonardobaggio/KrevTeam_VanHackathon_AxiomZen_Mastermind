using MasterMindApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MasterMindApi.Controllers
{
    public class UserApiController : ApiController
    {     
        
        public IEnumerable<Users> Get()
        {
            using (var context = new MastermindEntities())
            {
                return context.Users;
            }
        }

        // GET api/user/5
        public Users Get(int id)
        {
            using (var context = new MastermindEntities())
            {
                var user = context.Users.Where(x => x.UserId == id).FirstOrDefault();                

                return user;
            }
        }

        // POST api/user
        public void Post(Users user)
        {
            using (var context = new MastermindEntities())
            {
                context.Database.Connection.Open();

                var lstUsers = context.Users.Where(x => x.UserName == user.UserName).ToList();

                if (lstUsers.Count > 0)
                    //Send message that user already exists
                    return;

                context.Users.Add(user);
                context.SaveChanges();
            }
            
       
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
