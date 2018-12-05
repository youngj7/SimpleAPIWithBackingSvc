using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAPIWithBackingSvc.Models;
using SimpleAPIWithBackingSvc.Repositories;

namespace SimpleAPIWithBackingSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SimpleAPIContext _context;

        public UsersController(SimpleAPIContext context)
        {
            _context = context;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.Users;
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _context.Users
                .Where(x=>x.ID == id)
                .FirstOrDefault();
        }

        // POST api/users
        [HttpPost]
        public ActionResult<User> Post([FromBody] User value)
        {
            if (value == null) return null;

            User existingUser = _context.Users
                .Where(x=>x.ID == value.ID)
                .FirstOrDefault();

            if (existingUser != null)
                return null;

            _context.Users.Add(value);
            _context.SaveChanges();

            return value;
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            if (value == null) return;

            User existingUser = _context.Users
                .Where(x=>x.ID == value.ID)
                .FirstOrDefault();

            existingUser.Username = value.Username;
            _context.Users.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id < 1) return;

            User existingUser = _context.Users
                .Where(x=>x.ID == id)
                .FirstOrDefault();
           
            _context.Users.Remove(existingUser);
            _context.SaveChanges();
        }
    }
}
