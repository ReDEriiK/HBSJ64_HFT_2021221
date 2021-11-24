using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HBSJ64_HFT_2021221.Models
{
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set;}
        public string Title { get; set; }
        public string Genre { get; set; }
        public int DateOfPublish { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Actor Actor { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Director Director { get; set; }

        [ForeignKey(nameof(Director))]
        public int DirectorId { get; set; }

        [ForeignKey(nameof(Actor))]
        public int ActorId { get; set; }

    }
}
