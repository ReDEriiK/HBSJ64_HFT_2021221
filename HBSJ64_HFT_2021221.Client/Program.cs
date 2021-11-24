
using HBSJ64_HFT_2021221.Models;
using System;
using System.Linq;

namespace HBSJ64_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:4472");
            var films = rest.Get<Film>("Film");
            var actors = rest.Get<Actor>("Actor");
            var directors = rest.Get<Director>("Director");
        }
    }
}
