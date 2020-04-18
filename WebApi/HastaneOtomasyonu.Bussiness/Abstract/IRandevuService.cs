using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IRandevuService
    {
        Randevu GetById(int randevuId);
        List<Randevu> GetByDoktorId(int doktorId);
        List<Randevu> GetByHastaId(int hastaID);
        List<Randevu> GetByRandevu(int doktorId, int hastaId);
        void Create(Randevu entity);
        void Delete(Randevu entity);
        void Update(Randevu entity);
    }
}
