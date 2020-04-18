using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class AdminManager : IAdminService
    {
        IAdminRepository AdminRepo;
        public AdminManager(IAdminRepository adminRepo)
        {
            AdminRepo = adminRepo;
        }

        public Admin GetByAdmin(string kullaniciAdi, string parola)
        {
            Admin entity = AdminRepo.GetOne(i => i.KullaniciAdi == kullaniciAdi && i.Parola == parola);

            return entity;
        }
    }
}
