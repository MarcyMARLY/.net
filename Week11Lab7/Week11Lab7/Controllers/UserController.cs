using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week11Lab7.Data;
using Week11Lab7.Model;

namespace Week11Lab7.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserContext context;

        public UserController(UserContext userContext)
        {
            context = userContext;
        }
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            var collection = context.Users;

            return collection.ToList();
        }
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = context.Users.Where(x => x.id == id).First();
            if(user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
        [HttpPost]
        public IActionResult Create([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var newUser = new User {
                id = user.id,
                name = user.name,
                age = user.age,
                mark = user.mark,
                category = user.category
            };
            this.context.Users.Add(newUser);
            context.SaveChanges();
            return CreatedAtRoute("GetUser", new {
                id = user.id,
                name = user.name,
                age = user.age,
                mark = user.mark,
                category = user.category
            },newUser);
        }
        [HttpPut("{id}")]
        public User Update(int id, [FromBody] User user)
        {
            var newUser = new User
            {
                id = user.id,
                name = user.name,
                age = user.age,
                mark = user.mark,
                category = user.category
            };
            this.context.Users.Update(newUser);
            context.SaveChanges();
            return user;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = context.Users.Where(x => x.id == id).FirstOrDefault();
            this.context.Users.Remove(user);
            this.context.SaveChanges();
            return NoContent();
        }

    }
}