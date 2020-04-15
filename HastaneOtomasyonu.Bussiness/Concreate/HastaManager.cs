using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class HastaManager : IHastaService
    {
        IHastaRepository repo;
        public HastaManager(IHastaRepository repo)
        {
            this.repo = repo;
        }

        public void Create(Hasta entity)
        {
            repo.Create(entity);
        }

        public void Delete(Hasta entity)
        {
            repo.Delete(entity);
        }

        public Hasta GetByHasta(string tc, string parola)
        {
            return repo.GetOne(i => i.TC == tc && i.Parola == parola);
        }

        public Hasta GetByID(int hastaId)
        {
            return repo.GetById(hastaId);
        }

        public void Update(Hasta entity)
        {
            repo.Update(entity);
        }
        public bool GetByTc(string tc)
        {
            return repo.GetOne(i => i.TC == tc) == null ? false : true;
        }
    }
}
