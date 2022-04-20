using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSJ64_HFT_2021221.Models;
using HBSJ64_HFT_2021221.Logic;
using Microsoft.AspNetCore.SignalR;
using HBSJ64_HFT_2021221.Endpoint.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HBSJ64_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorLogic al;
        IHubContext<SignalRHub> hub;
        public ActorController(IActorLogic al, IHubContext<SignalRHub> hub)
        {
            this.al = al;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ActorCreated", value);
        }

        // PUT api/<ActorController>/5
        [HttpPut]
        public void Put([FromBody] Actor value)
        {
            al.Update(value);
            this.hub.Clients.All.SendAsync("ActorUpdated", value);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var actorToDelete = this.al.Read(id);
            al.Delete(id);
            this.hub.Clients.All.SendAsync("ActorDeleted", actorToDelete);
        }
    }
}
