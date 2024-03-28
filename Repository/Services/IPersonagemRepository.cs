using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Request.Personagem;
using Comics.DTOs.Response.Generic;
using Comics.Model;

namespace Comics.Repository.Services
{
    public interface IPersonagemRepository 
    {
        Task<ResponseGenericDTO> Create(CreatePersonagemRequestDto personagem);
        Task<ResponseGenericDTO> Update(UpdatePersonagemRequestDto personagem);
        Task<ResponseGenericDTO> Delete(int id);
        Task<IEnumerable<dynamic>> Read();
        Task<Personagem> ReadId(int id);
    }
}