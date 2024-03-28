using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Artista;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;

namespace Comics.Repository.Services
{
    public interface IArtistaRepository 
    {
        Task<ResponseGenericDTO> Create(CreateArtistaRequestDto artista);
        Task<ResponseGenericDTO> Update(UpdateArtistaRequestDto artista);
        Task<ResponseGenericDTO> Delete(int id);
        Task<IEnumerable<dynamic>> Read();
        Task<Artista> ReadId(int id);

    }
}