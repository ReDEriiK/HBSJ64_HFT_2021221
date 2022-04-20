using HBSJ64_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.WPFClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Actor> Actors { get; set; }
        public RestCollection<Director> Directors { get; set; }
        public RestCollection<Film> Films { get; set; }
        public MainWindowViewModel()
        {
            Actors = new RestCollection<Actor>("http://localhost:4472/", "actor");
            Directors = new RestCollection<Director>("http://localhost:4472/", "director");
            Films = new RestCollection<Film>("http://localhost:4472/", "film");
        }
    }
}
