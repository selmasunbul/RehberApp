using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class RaporModel
    {
        public string Konum { get; set; } = "";
        public int KisiSayisi { get; set; }
        public int TelefonNoSayisi { get; set; }
        public string? RaporDurumu { get; set; } = "";
        public DateTime TalepTarihi { get; set; }
    }
}
