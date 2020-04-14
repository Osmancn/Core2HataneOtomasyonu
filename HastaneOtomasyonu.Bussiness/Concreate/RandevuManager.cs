using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class RandevuManager : IRandevuService
    {
        IRandevuRepository repo;
        public RandevuManager(IRandevuRepository repo)
        {
            this.repo = repo;
        }
        public void Create(Randevu entity)
        {
            repo.Create(entity);
        }

        public void Delete(Randevu entity)
        {
            repo.Delete(entity);
        }

        public List<Randevu> GetByDoktorId(int doktorId)
        {
            return repo.GetAll(i => i.DoktorId == doktorId).ToList();
        }

        public List<Randevu> GetByHastaId(int hastaID)
        {
            return repo.GetAll(i => i.HastaId == hastaID).ToList();
        }

        public Randevu GetById(int randevuId)
        {
            return repo.GetById(randevuId);
        }

        public List<Randevu> GetByRandevu(int doktorId, int hastaId)
        {
            return repo.GetAll(i => i.HastaId == hastaId&&i.DoktorId==doktorId).ToList();
        }

        public void Update(Randevu entity)
        {
            repo.Update(entity);
        }
    }
}
