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
        IEnumerable<int> HowManyFilmDoesHeSheActedOn(int id);
        IEnumerable<KeyValuePair<string, string>> DirectorsWorkedWith(int id);
        IEnumerable<KeyValuePair<string, string>> GenresWhereActed(int id);
    }
}
