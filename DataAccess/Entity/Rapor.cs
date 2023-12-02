using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace DataAccess.Entity
{
    [DataContract]
    [Table("Rapor")]
    public class Rapor: EntityBase
    {
        [Column]
        [DataMember]
        [Display(Name = "Rapor Durumu")]
        [Required]
        public string RaporDurumu { get; set; } = "";

        [Column]
        [DataMember]
        [Display(Name = "Konum")]
        [Required]
        public string Konum { get; set; } = "";
        
        [Column]
        [DataMember]
        [Display(Name = "Kişi Sayısı")]
        [Required]
        public int KisiSayisi { get; set; } 

        [Column]
        [DataMember]
        [Display(Name = "Kişi Sayısı")]
        [Required]
        public int TelefonNoSayisi { get; set; } 


    }
}
