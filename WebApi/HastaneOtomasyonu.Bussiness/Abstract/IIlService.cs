using HastaneOtomasyonu.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HastaneOtomasyonu.Bussiness.Abstract
{
    public interface IIlService
    {
        Il GetById(int ilId);
        List<Il> GetAll();
    }
}
