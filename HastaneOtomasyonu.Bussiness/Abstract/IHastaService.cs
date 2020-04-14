using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IHastaService
    {
        Hasta GetByID(int hastaId);
        Hasta GetByHasta(string tc, string parola);

        void Create(Hasta entity);
        void Delete(Hasta entity);
        void Update(Hasta entity);
    }
}
