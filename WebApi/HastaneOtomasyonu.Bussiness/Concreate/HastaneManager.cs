using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class HastaneManager : IHastaneService
    {
        IHastaneRepository Repo;

        public HastaneManager(IHastaneRepository repo)
        {
            Repo = repo;
        }
        public void Create(Hastane entity)
        {
            Repo.Create(entity);
        }

        public void Delete(Hastane entity)
        {
            Repo.Delete(entity);
        }

        public List<Hastane> GetAll()
        {
            return Repo.GetAll().ToList();
        }

        public Hastane GetById(int hastaneId)
        {
            return Repo.GetById(hastaneId);
        }

        public List<Hastane> GetByIlId(int ilID)
        {
            return Repo.GetAll(i=>i.ilId==ilID).ToList();
        }

        public void Update(Hastane entity)
        {
            Repo.Update(entity);
        }
    }
}
