using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasHexagonal.Domain.Core.Responses
{
    public class AppResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }

        public string? Message { get; set; }

    }
}
