using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Artista;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly IArtistaRepository _repository;

        public ArtistaController(IArtistaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateArtista")]
        public async Task<ResponseGenericDTO> Create(CreateArtistaRequestDto artista)
        {
            return await _repository.Create(artista);
        }

        [HttpGet("ReadTodosArtistas")]
        public async Task<IEnumerable<dynamic>> Read()
        {
            return await _repository.Read();
        }

        [HttpGet("ReadArtista/{id}")]
        public async Task<ActionResult<Artista>> ReadId(int id)
        {
            var resposta = await _repository.ReadId(id);
            if (resposta != null) return Ok(resposta);
            return NotFound("Artista não encontrado");
        }

        [HttpDelete("DeleteArtista/{id}")]
        public async Task<ResponseGenericDTO> Delete(int id)
        {
            return await _repository.Delete(id);
         
        }

        
        [HttpPatch("UpdateArtista")]
        public async Task<ResponseGenericDTO> Update(UpdateArtistaRequestDto artista)
        {
            return await _repository.Update(artista);
          
        }
        
    }
}