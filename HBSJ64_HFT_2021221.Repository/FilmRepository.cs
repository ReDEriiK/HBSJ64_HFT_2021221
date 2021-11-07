using HBSJ64_HFT_2021221.Data;
using HBSJ64_HFT_2021221.Models;
using System;
using System.Linq;

namespace HBSJ64_HFT_2021221.Repository
{
    public class FilmRepository : IFilmRepository
    {
        FilmDbContext fdbc;
        public FilmRepository(FilmDbContext db)
        {
            fdbc = db;
        }

        public void Create(Film film)
        {
            fdbc.Films.Add(film);
            fdbc.SaveChanges();
        }

        public void Delete(int id)
        {
            var filmToDelete = Read(id);
            fdbc.Films.Remove(filmToDelete);
            fdbc.SaveChanges();
        }

        public IQueryable<Film> GetAll()
        {
            return fdbc.Films;
        }

        public Film Read(int id)
        {
            return fdbc.Films.FirstOrDefault(x => x.FilmId == id);
        }

        public void Update(Film film)
        {
            var filmToUpdate = Read(film.FilmId);
            filmToUpdate.Title = film.Title;
            filmToUpdate.Genre = film.Genre;
            filmToUpdate.DateOfPublish = film.DateOfPublish;
            filmToUpdate.ActorId = film.ActorId;
            filmToUpdate.DirectorId = film.DirectorId;
            fdbc.SaveChanges();
        }
    }
}
