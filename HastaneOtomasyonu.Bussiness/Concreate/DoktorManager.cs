using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class DoktorManager : IDoktorService
    {
        IDoktorRepository DoktorRepo;
        public DoktorManager(IDoktorRepository doktorRepo)
        {
            DoktorRepo = doktorRepo;
        }
        public void Create(Doktor entity)
        {
            DoktorRepo.Create(entity);
        }
        public Doktor GetByDoktor(string tc, string Parola)
        {
            return DoktorRepo.GetOne(i => i.TC == tc && i.Parola == Parola);
        }
        public void Delete(Doktor entity)
        {
            DoktorRepo.Delete(entity);
        }

        public List<Doktor> GetByBolumId(int BolumId)
        {
            return DoktorRepo.GetAll(i => i.BolumId == BolumId).ToList();
        }

        public Doktor GetById(int DoktorId)
        {
            return DoktorRepo.GetById(DoktorId);
        }

        public void Update(Doktor entity)
        {
            DoktorRepo.Update(entity);
        }

        public bool GetByTc(string tc)
        {
            return DoktorRepo.GetOne(i => i.TC == tc) == null ? false : true;
        }
    }
}
