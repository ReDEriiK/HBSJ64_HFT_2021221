using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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
        public FilmController(IFilmLogic fl)
        {
            this.fl = fl;
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
        }

        // PUT api/<FilmController>/5
        [HttpPut]
        public void Put([FromBody] Film value)
        {
            fl.Update(value);
        }

        // DELETE api/<FilmController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fl.Delete(id);
        }

    }
}
