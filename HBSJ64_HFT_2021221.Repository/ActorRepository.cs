using HBSJ64_HFT_2021221.Data;
using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Repository
{
    public class ActorRepository : IActorRepository
    {
        FilmDbContext fdbc;
        public ActorRepository(FilmDbContext db)
        {
            fdbc = db;
        }
        public void Create(Actor actor)
        {
            fdbc.Actors.Add(actor);
            fdbc.SaveChanges();
        }

        public void Delete(int id)
        {
            var actorToDelete = Read(id);
            fdbc.Actors.Remove(actorToDelete);
            fdbc.SaveChanges();
        }

        public IQueryable<Actor> GetAll()
        {
            return fdbc.Actors;
        }

        public Actor Read(int id)
        {
            return fdbc.Actors.FirstOrDefault(x => x.ActorId == id);
        }

        public void Update(Actor actor)
        {
            var actorToUpdate = Read(actor.DirectorId);
            actorToUpdate.Name = actor.Name;
            actorToUpdate.Age = actor.Age;
            actorToUpdate.Awards = actor.Awards;
            fdbc.SaveChanges();
        }
    }
}
