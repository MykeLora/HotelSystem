using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Core
{
    public class ServiceResut<TData>
    {

        public bool? Success { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }


        public ServiceResut()
        {
            this.Success = true;
            
        }
    }
}
