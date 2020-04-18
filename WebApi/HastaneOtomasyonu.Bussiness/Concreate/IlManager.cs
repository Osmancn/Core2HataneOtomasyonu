using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Concreate
{
    public class IlManager : IIlService
    {
        IIlRepository repo;
        public IlManager(IIlRepository repo)
        {
            this.repo = repo;
        }

        public List<Il> GetAll()
        {
            return repo.GetAll().ToList();
        }

        public Il GetById(int ilId)
        {
            return repo.GetById(ilId);
        }
    }
}
