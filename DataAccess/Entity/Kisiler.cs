using DataAccess.Base;
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
        public Guid İletisimBilgisiId { get; set; }


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
        [DataMember(IsRequired = false)]
        [ForeignKey("İletisimBilgisiId")]
        public virtual İletisimBilgisi? İletisimBilgisi { get; set; }
    }
}