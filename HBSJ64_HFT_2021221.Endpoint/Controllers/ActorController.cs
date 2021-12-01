using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSJ64_HFT_2021221.Models;
using HBSJ64_HFT_2021221.Logic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HBSJ64_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorLogic al;
        public ActorController(IActorLogic al)
        {
            this.al = al;
        }


        // GET: api/<ActorController>
        [HttpGet]
        public IEnumerable<Actor> Get()
        {
            return al.GetAll();
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public Actor Get(int id)
        {
            return al.Read(id);
        }

        // POST api/<ActorController>
        [HttpPost]
        public void Post([FromBody] Actor value)
        {
            al.Create(value);
        }

        // PUT api/<ActorController>/5
        [HttpPut]
        public void Put([FromBody] Actor value)
        {
            al.Update(value);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            al.Delete(id);
        }
        public Actor GetSingle(int id)
        {
            return al.Read(id);
        }
    }
}
