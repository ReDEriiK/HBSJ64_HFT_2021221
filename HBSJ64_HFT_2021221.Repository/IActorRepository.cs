using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Repository
{
    public interface IActorRepository
    {
        void Create(Actor actor);
        void Delete(int id);
        IQueryable<Actor> GetAll();
        Actor Read(int id);
        void Update(Actor actor);
    }
}
