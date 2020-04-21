using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IBolumService
    {
        Bolum GetById(int id);
        List<Bolum> GetByHastaneId(int hastaneId);
        List<Bolum> GetAll();
        void Create(Bolum entity);
        void Update(Bolum entity);
        void Delete(Bolum entity);
    }
}
