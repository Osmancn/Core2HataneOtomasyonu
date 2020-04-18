using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Entity
{
    public class Hasta
    {
        public int HastaId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public bool Cinsiyet { get; set; }
    }
}
