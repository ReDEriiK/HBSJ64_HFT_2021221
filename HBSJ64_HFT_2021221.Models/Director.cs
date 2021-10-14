using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Models
{
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Award { get; set; }

        public virtual ICollection<Film> Films { get; set; }

        [ForeignKey(nameof(Film))]
        public int FilmId { get; set; }
        public Director()
        {
            Films = new HashSet<Film>();
        }

    }
}
