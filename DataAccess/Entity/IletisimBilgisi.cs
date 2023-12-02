using DataAccess.Base;
using DataAccess.Context;
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
        [Display(Name = "Kişi")]
        [Required]
        public Guid KisiId { get; set; }


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
        public virtual string BilgiTipiAdi => GetBilgiTipiAdi(this.BilgiTipiId);

        private string GetBilgiTipiAdi(Guid bilgiTipiId)
        {
            using (DBContext ctx = new DBContext())
            {
                var InternalBilgiTipi = ctx.InternalBilgiTipi
                    .Where(ic => ic.Id == bilgiTipiId)
                    .Select(x => x.Adı)
                    .FirstOrDefault();  

                return InternalBilgiTipi ?? ""; 
            }
        }

        [NotMapped]
        [DataMember(IsRequired = false)]
        [ForeignKey("KisiId")]
        public virtual Kisi? Kisi { get; set; }
    }
}
