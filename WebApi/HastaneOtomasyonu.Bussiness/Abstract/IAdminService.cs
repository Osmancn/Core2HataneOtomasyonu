using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IAdminService
    {
        Admin GetByAdmin(string kullaniciAdi,string parola);
    }
}
