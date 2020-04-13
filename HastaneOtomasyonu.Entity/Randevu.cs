using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Entity
{
    public class Randevu
    {
        public int RandevuId { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public int HastaId { get; set; }
        public virtual Hasta Hasta { get; set; }
        public int DoktorId { get; set; }
        public virtual Doktor Doktor { get; set; }
     
    }
}
