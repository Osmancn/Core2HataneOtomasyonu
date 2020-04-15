using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.WebAPI.ViewModels
{
    public class ServiceResponse<T>:BaseResponse 
        where T:class
    {
        public T entity { get; set; }
        public List<T> entities { get; set; }
        public ServiceResponse()
        {
            entities = new List<T>();
            Errors = new List<string>();
            HasError = false;
            IsSuccessful = false;
        }
    }
}
