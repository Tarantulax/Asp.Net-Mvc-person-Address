using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _04032022_EFCodeFirst.Models
{
    [Table("Adresler")]
    public class Adresler
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(200)]
        public string AdresTanim { get; set; }

        public virtual Kisiler Kisi { get; set; }
    }
}