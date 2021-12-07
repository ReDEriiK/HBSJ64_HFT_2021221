using HBSJ64_HFT_2021221.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HBSJ64_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IFilmLogic fl;
        IActorLogic al;
        IDirectorLogic dl;
        public StatController(IFilmLogic fl, IActorLogic al, IDirectorLogic dl)
        {
            this.fl = fl;
            this.al = al;
            this.dl = dl;
        }
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<string, string>> FilmActors(int id)
        {
            return fl.FilmActors(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<string, string>> FilmDirectors(int id)
        {
            return fl.FilmDirectors(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<int> HowManyFilmDoesHeSheActedOn(int id)
        {
            return al.HowManyFilmDoesHeSheActedOn(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<int> HowManyFilmDoesHeSheHave(int id)
        {
            return dl.HowManyFilmDoesHeSheHave(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<int, string>> GendreOfDirectedFilms(int id)
        {
            return dl.GendreOfDirectedFilms(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<int> CountOfActorAwards(int id)
        {
            return fl.CountOfActorAwards(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<int> CountOfDirectorAwards(int id)
        {
            return fl.CountOfDirectorAwards(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<string, string>> ActorsWorkedWith(int id)
        {
            return dl.ActorsWorkedWith(id);
        }
        [HttpGet("{id}")]
        public IEnumerable<KeyValuePair<string, string>> DirectorsWorkedWith(int id)
        {
            return al.DirectorsWorkedWith(id);
        }

    }
}
