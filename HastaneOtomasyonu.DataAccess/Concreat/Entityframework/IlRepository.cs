using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.DataAccess.Concreat.Entityframework
{
    public class IlRepository:GenericRepository<Il,HastaneOtomasyonuDbContext>,IIlRepository
    {
    }
}
