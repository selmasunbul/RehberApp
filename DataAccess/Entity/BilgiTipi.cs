using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess
{
    [DataContract]
    [Table("BilgiTipi")]
    public class BilgiTipi: EntityBase
    {
        [Column]
        [DataMember]
        [Display(Name = "Adı")]
        [Required]
        public string Adı { get; set; } = "";

        [NotMapped]
        [InverseProperty("BilgiTipi")]
        public virtual ICollection<İletisimBilgisi>? İletisimBilgileri { get; set; }

    }
}
