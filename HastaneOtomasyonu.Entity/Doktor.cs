using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Entity
{
    public class Doktor
    {
        public int DoktorId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public bool Cinsiyet { get; set; }

        public int BolumId { get; set; }
        public virtual Bolum Bolum { get; set; }
    }
}
