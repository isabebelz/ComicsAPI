using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comic;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;

namespace Comics.Repository.Services
{
    public interface IComicRepository
    {
        Task<ResponseGenericDTO> Create(CreateComicRequestDto comic);
        Task<ResponseGenericDTO> Update(UpdateComicRequestDto comic);
        Task<ResponseGenericDTO> Delete(int id);
        Task<IEnumerable<dynamic>> Read();
        Task<Comic> ReadId(int id);
    }
}