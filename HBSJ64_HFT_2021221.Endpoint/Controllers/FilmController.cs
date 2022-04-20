using HBSJ64_HFT_2021221.Endpoint.Services;
using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace HBSJ64_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        IFilmLogic fl;
        IHubContext<SignalRHub> hub;
        public FilmController(IFilmLogic fl, IHubContext<SignalRHub> hub)
        {
            this.fl = fl;
            this.hub = hub;
        }

        // GET: api/<FilmController>
        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return fl.GetAll();
        }

        // GET api/<FilmController>/5
        [HttpGet("{id}")]
        public Film Get(int id)
        {
            return fl.Read(id);
        }

        // POST api/<FilmController>
        [HttpPost]
        public void Post([FromBody] Film value)
        {
            fl.Create(value);
            this.hub.Clients.All.SendAsync("FilmCreated", value);
        }

        // PUT api/<FilmController>/5
        [HttpPut]
        public void Put([FromBody] Film value)
        {
            fl.Update(value);
            this.hub.Clients.All.SendAsync("FilmUpdated", value);
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var filmToDelete = this.fl.Read(id);
            fl.Delete(id);
            this.hub.Clients.All.SendAsync("FilmDelete", filmToDelete);
        }

    }
}
