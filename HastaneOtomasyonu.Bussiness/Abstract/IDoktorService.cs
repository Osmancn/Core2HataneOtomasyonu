using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IDoktorService
    {
        Doktor GetById(int DoktorId);
        List<Doktor> GetByBolumId(int BolumId);
        void Create(Doktor entity);
        void Delete(Doktor entity);
        void Update(Doktor entity);

    }
}
