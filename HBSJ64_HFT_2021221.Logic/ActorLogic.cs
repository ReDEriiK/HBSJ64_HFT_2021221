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
            if (actor.Name == null)
            {
                throw new ArgumentNullException();
            }
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

        public IEnumerable<int> HowManyFilmDoesHeSheActedOn(int id)
        {
            var res = actorRepo.GetAll().Where(x => x.ActorId == id).Select(x => x.Films.Count());
            return res;
        }
        public IEnumerable<KeyValuePair<string, string>> DirectorsWorkedWith(int id)
        {
            var res = from x in actorRepo.GetAll().Where(y => y.ActorId == id).SelectMany(Y => Y.Films)
                      select new KeyValuePair<string, string>(x.Title, x.Director.Name);
            return res;
        }
        public IEnumerable<KeyValuePair<string, string>> GenresWhereActed(int id)
        {
            var res = from x in actorRepo.GetAll().Where(y => y.ActorId == id).SelectMany(Y => Y.Films)
                      select new KeyValuePair<string, string>(x.Title, x.Genre);
            return res;
        }
    }
}
