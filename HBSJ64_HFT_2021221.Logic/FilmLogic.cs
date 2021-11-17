using HBSJ64_HFT_2021221.Models;
using HBSJ64_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Logic
{
    public class FilmLogic : IFilmLogic
    {
        ////////////////////////////////////////////////////////////////////////
        IFilmRepository filmRepo;
        public FilmLogic(IFilmRepository filmRepo)
        {
            this.filmRepo = filmRepo;
        }
        ////////////////////////////////////////////////////////////////////////
        public void Create(Film film)
        {
            filmRepo.Create(film);
        }
        public void Delete(int id)
        {
            filmRepo.Delete(id);
        }
        public IEnumerable<Film> GetAll()
        {
            return filmRepo.GetAll();
        }
        public Film Read(int id)
        {
            return filmRepo.Read(id);
        }
        public void Update(Film film)
        {
            filmRepo.Update(film);
        }
        ////////////////////////////////////////////////////////////////////////
        public IEnumerable<KeyValuePair<string, string>> FilmActors(int id)
        {
            var res = from x in filmRepo.GetAll()
                      where x.FilmId == id
                      select new
                      {
                          Title = x.Title,
                          Acted = x.Actor.Name,
                      };
            return (IEnumerable<KeyValuePair<string, string>>)res;
        }
        public IEnumerable<KeyValuePair<string, string>> FilmDirectors(int id)
        {
            var res = from x in filmRepo.GetAll()
                      where x.FilmId == id
                      select new
                      {
                          Title = x.Title,
                          Directed = x.Director.Name,
                      };
            return (IEnumerable<KeyValuePair<string, string>>)res;
        }
    }
}
