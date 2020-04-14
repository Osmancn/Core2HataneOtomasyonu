using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class BolumManager : IBolumService
    {
        IBolumRepository BolumRepo;

        public BolumManager(IBolumRepository bolumRepo)
        {
            BolumRepo = bolumRepo;
        }


        public void Create(Bolum entity)
        {
            BolumRepo.Create(entity);
        }

        public void Delete(Bolum entity)
        {
            BolumRepo.Delete(entity);
        }

        public List<Bolum> GetByHastaneId(int hastaneId)
        {
            List<Bolum> bolumler;

            bolumler = BolumRepo.GetAll(i=>i.HastaneId==hastaneId).ToList();

            return bolumler;
        }

        public Bolum GetById(int id)
        {
            return BolumRepo.GetById(id);
        }

        public void Update(Bolum entity)
        {
            BolumRepo.Update(entity);
        }
    }
}
