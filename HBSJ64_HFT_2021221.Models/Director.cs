﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HBSJ64_HFT_2021221.Models
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Award { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Film> Films { get; set; }

        public Director()
        {
            Films = new HashSet<Film>();
        }

    }
}
