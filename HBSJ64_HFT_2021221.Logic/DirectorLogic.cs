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
        public IEnumerable<Film> DirectedFilms(int id)
        {
            var res = from x in directorRepo.GetAll()
                      where x.DirectorId == id
                      select x.Films;
            return (IEnumerable<Film>)res;
        }

        public IEnumerable<string> GendresOfDirectedFilms(int id)
        {
            var res = from x in directorRepo.GetAll()
                      where x.DirectorId == id
                      select x.Films.Select(x => x.Genre);
            return (IEnumerable<string>)res;
        }
    }
}
