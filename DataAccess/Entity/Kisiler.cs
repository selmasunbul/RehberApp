using DataAccess.Base;
using DataAccess.Context;
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
        public virtual ICollection<IletisimBilgisi>? IletisimBilgileri => GetIletisimBilgileri(this.Id);

        private List<IletisimBilgisi> GetIletisimBilgileri(Guid kisiId)
        {
            using (DBContext ctx = new DBContext())
            {
                var internalIletisimBilgisiList = ctx.InternalIletisimBilgisi
                    .Where(ic => ic.KisiId == kisiId)
                    .ToList();  

                if (internalIletisimBilgisiList != null && internalIletisimBilgisiList.Any())
                {
                    return internalIletisimBilgisiList;
                }

                return new List<IletisimBilgisi>(); 
            }
        }

    }
}