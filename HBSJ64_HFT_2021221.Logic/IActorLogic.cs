using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Logic
{
    public interface IActorLogic
    {

        void Create(Actor actor);
        Actor Read(int id);
        void Update(Actor actor);
        void Delete(int id);
        IEnumerable<Actor> GetAll();
        IEnumerable<Film> ActedOn(int id);
        IEnumerable<string> GenresWherePlayed(int id);
    }
}
