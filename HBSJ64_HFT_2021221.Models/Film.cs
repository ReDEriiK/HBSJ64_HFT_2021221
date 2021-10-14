using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HBSJ64_HFT_2021221.Models
{
    public class Film
    {
        [Key]
        public int FilmId { get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public int DateOfPublish { get; set; }

        [NotMapped]
        public virtual Actor Actor { get; set; }
        [NotMapped]
        public virtual Director Director { get; set; }

        [ForeignKey(nameof(Director))]
        public int DirectorId { get; set; }

        [ForeignKey(nameof(Actor))]
        public int MainActorId { get; set; }

    }
}
