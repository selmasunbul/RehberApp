using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class KisiModel
    {
        public Guid İletisimBilgisiId { get; set; }
        public string Adı { get; set; } = "";
        public string SoyAdi { get; set; } = "";
        public string Firma { get; set; } = "";

    }
}
