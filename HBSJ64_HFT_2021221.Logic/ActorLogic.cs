using HBSJ64_HFT_2021221.Models;
using HBSJ64_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Logic
{
    public class ActorLogic : IActorLogic
    {
        ////////////////////////////////////////////////////////////////////////
        IActorRepository actorRepo;
        public ActorLogic(IActorRepository actorRepo)
        {
            this.actorRepo = actorRepo;
        }
        ////////////////////////////////////////////////////////////////////////
        public void Create(Actor actor)
        {
            actorRepo.Create(actor);
        }
        public void Delete(int id)
        {
            actorRepo.Delete(id);
        }
        public IEnumerable<Actor> GetAll()
        {
            return actorRepo.GetAll();
        }
        public Actor Read(int id)
        {
            return actorRepo.Read(id);
        }
        public void Update(Actor actor)
        {
            actorRepo.Update(actor);
        }
        ////////////////////////////////////////////////////////////////////////
        public IEnumerable<Film> ActedOn(int id)
        {
            var res = from x in actorRepo.GetAll()
                      where x.ActorId == id
                      select x.Films;
            return (IEnumerable<Film>)res;
        }
        public IEnumerable<string> GenresWherePlayed(int id)
        {
            var res = from x in actorRepo.GetAll()
                      where x.ActorId == id
                      select x.Films.Select(x => x.Genre);
            return (IEnumerable<string>)res;
        }
    }
}
