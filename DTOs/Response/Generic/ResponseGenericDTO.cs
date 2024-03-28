using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.DTOs.Response.Generic
{
    public class ResponseGenericDTO
    {
        public ResponseDTO Resposta { get; set; }
        public object Dado { get; set; }
        
    }
}