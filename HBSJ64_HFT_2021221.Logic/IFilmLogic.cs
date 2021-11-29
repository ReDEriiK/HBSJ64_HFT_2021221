using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Logic
{
    public interface IFilmLogic
    {
        void Create(Film film);
        Film Read(int id);
        void Update(Film film);
        void Delete(int id);
        IEnumerable<Film> GetAll();
        IEnumerable<KeyValuePair<string, string>> FilmActors(int id);
        IEnumerable<KeyValuePair<string, string>> FilmDirectors(int id);
        IEnumerable<int> CountOfActorAwards(int id);
        IEnumerable<int> CountOfDirectorAwards(int id);
    }
}
