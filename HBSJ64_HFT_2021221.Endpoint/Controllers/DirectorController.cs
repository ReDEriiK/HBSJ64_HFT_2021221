using HBSJ64_HFT_2021221.Logic;
using HBSJ64_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HBSJ64_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        IDirectorLogic dl;
        public DirectorController(IDirectorLogic dl)
        {
            this.dl = dl;
        }





        // GET: api/<DirectorController>
        [HttpGet]
        public IEnumerable<Director> Get()
        {
            return dl.GetAll();
        }

        // GET api/<DirectorController>/5
        [HttpGet("{id}")]
        public Director Get(int id)
        {
            return dl.Read(id);
        }

        // POST api/<DirectorController>
        [HttpPost]
        public void Post([FromBody] Director value)
        {
            dl.Create(value);
        }

        // PUT api/<DirectorController>/5
        [HttpPut]
        public void Put([FromBody] Director value)
        {
            dl.Update(value);
        }

        // DELETE api/<DirectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dl.Delete(id);
        }
        [HttpGet("{id}")]
        public Director GetSingle(int id)
        {
            return dl.Read(id);
        }
    }
}
