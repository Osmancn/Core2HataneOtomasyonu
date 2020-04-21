using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IDoktorService
    {
        Doktor GetById(int DoktorId);
        List<Doktor> GetAll();
        List<Doktor> GetByBolumId(int BolumId);
        Doktor GetByDoktor(string tc, string Parola);
        bool GetByTc(string tc);
        void Create(Doktor entity);
        void Delete(Doktor entity);
        void Update(Doktor entity);

    }
}
