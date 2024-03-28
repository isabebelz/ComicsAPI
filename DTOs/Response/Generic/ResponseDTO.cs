using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.DTOs.Response.Generic
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        
        public ResponseDTO() {}

        public ResponseDTO(int statusCode)
        {
            StatusCode = statusCode;
            Message = string.Empty;
        }

        public ResponseDTO(int statusCode, string? message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}