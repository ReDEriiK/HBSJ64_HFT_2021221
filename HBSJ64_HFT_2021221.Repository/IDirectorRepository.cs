using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Repository
{
    public interface IDirectorRepository
    {
        void Create(Director director);
        void Delete(int id);
        IQueryable<Director> GetAll();
        Director Read(int id);
        void Update(Director director);
    }
}
