using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Entity
{
    public class Hastane
    {
        public int HastaneId { get; set; }
        public string HastaneAdi { get; set; }
        public string HastaneAdresi { get; set; }

        public int ilId { get; set; }
        public virtual Il il { get; set; }

        public virtual ICollection<Bolum> Bolumler { get; set; }

    }
}
