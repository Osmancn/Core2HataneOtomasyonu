using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.WebUI.ViewModel
{
    public class GirisViewModel
    {
        [Required(ErrorMessage = "Tc Zorunlu Alan")]
        [MaxLength(11,ErrorMessage ="Tc 11 basamalık olmak zorunda")]
        [MinLength(11, ErrorMessage = "Tc 11 basamalık olmak zorunda")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Tc sadece sayı olabilir")]
        public string Tc  { get; set; }

        [Required(ErrorMessage ="Parola Zorunlu Alan")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Parola en az 6 karakter olmak zorunda")]
        [MaxLength(18,ErrorMessage ="Parola en fazla 18 karakter olabilir")]
        public string Parola { get; set; }
    }
}
