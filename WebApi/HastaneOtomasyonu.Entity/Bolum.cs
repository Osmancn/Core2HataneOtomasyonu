using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Entity
{
    public class Bolum
    {
        public int BolumId { get; set; }
        public string BolumAdi { get; set; }
        public int HastaneId { get; set; }
        public virtual Hastane Hastane { get; set; }
        public virtual ICollection<Doktor> Doktorlar { get; set; }
    }
}
