using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Logic
{
    public interface IDirectorLogic
    {
        void Create(Director director);
        Director Read(int id);
        void Update(Director director);
        void Delete(int id);
        IEnumerable<Director> GetAll();
        IEnumerable<int> HowManyFilmDoesHeSheHave(int id);
        IEnumerable<KeyValuePair<int, string>> GendreOfDirectedFilms(int id);
        IEnumerable<KeyValuePair<string, string>> ActorsWorkedWith(int id);
    }
}
