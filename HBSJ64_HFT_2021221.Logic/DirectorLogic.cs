using HBSJ64_HFT_2021221.Models;
using HBSJ64_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Logic
{
    public class DirectorLogic : IDirectorLogic
    {
        ////////////////////////////////////////////////////////////////////////
        IDirectorRepository directorRepo;
        public DirectorLogic(IDirectorRepository directorRepo)
        {
            this.directorRepo = directorRepo;
        }
        ////////////////////////////////////////////////////////////////////////
        public void Create(Director director)
        {
            if (director.Name == null)
            {
                throw new ArgumentNullException();
            }
            directorRepo.Create(director);

        }
        public Director Read(int id)
        {
            return directorRepo.Read(id);
        }
        public void Update(Director director)
        {
            directorRepo.Update(director);
        }
        public void Delete(int id)
        {
            directorRepo.Delete(id);
        }
        public IEnumerable<Director> GetAll()
        {
            return directorRepo.GetAll();
        }
        ////////////////////////////////////////////////////////////////////////
        public IEnumerable<int> HowManyFilmDoesHeSheHave(int id)
        {
            var res = directorRepo.GetAll().Where(x => x.DirectorId == id).Select(x => x.Films.Count());
            return res;
        }

        public IEnumerable<KeyValuePair<string, string>> GenreOfDirectedFilms(int id)
        {
            
            var res = from x in directorRepo.GetAll().Where(y => y.DirectorId == id).SelectMany(Y => Y.Films)
                       select new KeyValuePair<string, string>(x.Title, x.Genre);   
            return res;
        }

        public IEnumerable<KeyValuePair<string, string>> ActorsWorkedWith(int id)
        {
            var res = from x in directorRepo.GetAll().Where(y => y.DirectorId == id).SelectMany(Y => Y.Films)
                      select new KeyValuePair<string, string>(x.Title, x.Actor.Name);
            return res;

        }
    }
}
