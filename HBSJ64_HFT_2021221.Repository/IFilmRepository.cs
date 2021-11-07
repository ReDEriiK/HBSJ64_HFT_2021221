using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Repository
{
    public interface IFilmRepository
    {
        void Create(Film film);
        void Delete(int id);
        IQueryable<Film> GetAll();
        Film Read(int id);
        void Update(Film film);
    }
}
