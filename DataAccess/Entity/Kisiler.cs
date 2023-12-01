﻿using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess
{
    [DataContract]
    [Table("Kisi")]
    public class Kisi: EntityBase
    {

        [Column]
        [DataMember]
        [Display(Name = "İletisim Bilgisi")]
        [Required]
        public Guid IletisimBilgisiId { get; set; }


        [Column]
        [DataMember]
        [Display(Name = "Adı")]
        [Required]
        public string Adı { get; set; } = "";

        [Column]
        [DataMember]
        [Display(Name = "Soyadı")]
        [Required]
        public string SoyAdi { get; set; } = "";
        
        [Column]
        [DataMember]
        [Display(Name = "Firma")]
        [Required]
        public string Firma { get; set; } = "";

        [NotMapped]
        [InverseProperty("Kisi")]
        public virtual ICollection<IletisimBilgisi>? IletisimBilgileri { get; set; }
    }
}