using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Autor;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;

namespace Comics.Repository.Services
{
    public interface IAutorRepository 
    {
        Task<ResponseGenericDTO> Create(CreateAutorRequestDto autor);
        Task<ResponseGenericDTO> Update(UpdateAutorRequestDto autor);
        Task<ResponseGenericDTO> Delete(int id);
        Task<IEnumerable<dynamic>> Read();
        Task<Autor> ReadId(int id);
    }
}