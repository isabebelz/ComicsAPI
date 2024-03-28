using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Request.Editora;
using Comics.DTOs.Response.Generic;
using Comics.Model;

namespace Comics.Repository.Services
{
    public interface IEditoraRepository 
    {
        Task<ResponseGenericDTO> Create(CreateEditoraRequestDto editora);
        Task<ResponseGenericDTO> Update(UpdateEditoraRequestDto editora);
        Task<ResponseGenericDTO> Delete(int id);
        Task<IEnumerable<dynamic>> Read();
        Task<Editora> ReadId(int id);
    }
}