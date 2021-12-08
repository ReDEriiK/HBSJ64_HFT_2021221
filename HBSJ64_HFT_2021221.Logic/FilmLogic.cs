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
            if (film.Title == null)
            {
                throw new ArgumentNullException();
            }
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
                      select new KeyValuePair<string, string>( x.Title, x.Actor.Name);
            return res;
        }
        public IEnumerable<KeyValuePair<string, string>> FilmDirectors(int id)
        {
            var res = from x in filmRepo.GetAll()
                      where x.FilmId == id
                      select new KeyValuePair<string, string>(x.Title, x.Director.Name);
            return res;
        }
        public IEnumerable<int> CountOfActorAwards(int id)
        {
            
            var actorAwards = filmRepo.GetAll().Where(x => x.FilmId == id).Select(x => x.Actor.Awards);
            return actorAwards;
            
        }
        public IEnumerable<int> CountOfDirectorAwards(int id)
        {
            var directorAwards = filmRepo.GetAll().Where(x => x.FilmId == id).Select(x => x.Director.Award);
            return directorAwards;

        }
        public IEnumerable<KeyValuePair<string, string>> FilmActorDirector(int id)
        {
            var res = from x in filmRepo.GetAll()
                      where x.FilmId == id
                      select new KeyValuePair<string, string>(x.Director.Name, x.Actor.Name);
            return res;
        }

        
    }
}
