using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Awards { get; set; }
        public virtual ICollection<Film> Films { get; set; }
        public Actor()
        {
            Films = new HashSet<Film>();
        }
    }
}
