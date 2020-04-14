using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IHastaneService
    {
        Hastane GetById(int hastaneId);
        List<Hastane> GetByIlId(int ilID);
        void Create(Hastane entity);
        void Update(Hastane entity);
        void Delete(Hastane entity);
        
    }
}
