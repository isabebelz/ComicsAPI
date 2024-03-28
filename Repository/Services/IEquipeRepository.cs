using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Equipe;
using Comics.DTOs.Response.Generic;
using Comics.Model;

namespace Comics.Repository.Services
{
    public interface IEquipeRepository 
    {
        Task<ResponseGenericDTO> Create(CreateEquipeRequestDto equipe);
        Task<ResponseGenericDTO> Update(UpdateEquipeRequestDto equipe);
        Task<ResponseGenericDTO> Delete(int id);
        Task<IEnumerable<dynamic>> Read();
        Task<Equipe> ReadId(int id);
    }
}