using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.WebUI.Models
{
    public class ServiceResponse<T> 
        where T : class
    {
        public T entity { get; set; }
        public List<T> entities { get; set; }
        public List<string> Errors { get; set; }
        public bool HasError { get; set; }
        public bool isSuccessful { get; set; }

        public ServiceResponse()
        {
            entities = new List<T>();
            Errors = new List<string>();
        }
    }
}
