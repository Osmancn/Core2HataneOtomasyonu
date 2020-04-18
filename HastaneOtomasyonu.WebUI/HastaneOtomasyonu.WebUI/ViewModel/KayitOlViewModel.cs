using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.WebUI.ViewModel
{
    public class KayitOlViewModel
    {
        [Required(ErrorMessage = "Tc Zorunlu Alan")]
        [MaxLength(11, ErrorMessage = "Tc 11 basamalık olmak zorunda")]
        [MinLength(11, ErrorMessage = "Tc 11 basamalık olmak zorunda")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Tc sadece sayı olabilir")]
        public string Tc { get; set; }

        [Required(ErrorMessage = "Parola Zorunlu Alan")]
        [MinLength(6, ErrorMessage = "Parola en az 6 karakter olmak zorunda")]
        [MaxLength(18, ErrorMessage = "Parola en fazla 18 karakter olabilir")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [DataType(DataType.Password)]
        [Compare("Parola",ErrorMessage ="Aynı parolayı giriniz")]
        public string ReParola { get; set; }

        [Required(ErrorMessage ="Ad Zorunlu Alan")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad Zorunlu Alan")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Email Zorunlu Alan")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Geçerli Email Giriniz")]
        public string Email { get; set; }

        public bool Cinsiyet { get; set; }
    }
}
