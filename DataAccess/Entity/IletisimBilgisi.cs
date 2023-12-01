﻿using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess
{
    [DataContract]
    [Table("İletisimBilgisi")]
    public class IletisimBilgisi: EntityBase
    {
        [Column]
        [DataMember]
        [Display(Name = "Bilgi Tipi")]
        [Required]
        public Guid BilgiTipiId { get; set; }

        [Column]
        [DataMember]
        [Display(Name = "İçerik")]
        [Required]
        public string İcerik { get; set; } = "";


        [NotMapped]
        [DataMember(IsRequired = false)]
        [ForeignKey("BilgiTipiId")]
        public virtual BilgiTipi? BilgiTipi { get; set; }

        [NotMapped]
        [InverseProperty("İletisimBilgisi")]
        public virtual ICollection<Kisi>? Kisiler { get; set; }

    }
}