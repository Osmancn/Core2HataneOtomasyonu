using HastaneOtomasyonu.DataAccess.Abstract;
using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HastaneOtomasyonu.DataAccess.Concreat.Entityframework
{
    public class HastaneRepository :GenericRepository<Hastane,HastaneOtomasyonuDbContext>, IHastaneRepository
    {
       
    }
}
