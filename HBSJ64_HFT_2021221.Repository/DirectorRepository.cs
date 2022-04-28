using HBSJ64_HFT_2021221.Data;
using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        FilmDbContext fdbc;
        public DirectorRepository(FilmDbContext db)
        {
            fdbc = db;
        }

        public void Create(Director director)
        {
            fdbc.Directors.Add(director);
            fdbc.SaveChanges();
        }

        public void Delete(int id)
        {
            var directorToDelete = Read(id);
            fdbc.Directors.Remove(directorToDelete);
            fdbc.SaveChangesAsync();
        }

        public IQueryable<Director> GetAll()
        {
            return fdbc.Directors;
        }

        public Director Read(int id)
        {
            return fdbc.Directors.FirstOrDefault(x => x.DirectorId == id);
        }

        public void Update(Director director)
        {
            var directorToUpdate = Read(director.DirectorId);
            directorToUpdate.Name = director.Name;
            directorToUpdate.Age = director.Age;
            directorToUpdate.Award = director.Award;
            fdbc.SaveChangesAsync();
        }
    }
}
