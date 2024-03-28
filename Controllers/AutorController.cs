using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Artista;
using Comics.DTOs.Request.Autor;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _repository;

        public AutorController(IAutorRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateAutor")]
        public async Task<ResponseGenericDTO> Create(CreateAutorRequestDto autor)
        {
            return await _repository.Create(autor);
        }

        [HttpGet("ReadTodosAutores")]
        public async Task<IEnumerable<dynamic>> Read()
        {
            return await _repository.Read();
        }

        [HttpGet("ReadAutor/{id}")]
        public async Task<ActionResult<AutorDTO>> ReadId(int id)
        {
            var responseAutor = await _repository.ReadId(id);

            if (responseAutor != null) return Ok(responseAutor);
            return NotFound("Autor não encontrado!");
        
        }

        [HttpDelete("DeleteAutor/{id}")]
        public async Task<ResponseGenericDTO> Delete(int id)
        {
            return await _repository.Delete(id);
         
        }

        
        [HttpPut("UpdateAutor")]
        public async Task<ResponseGenericDTO> Update(UpdateAutorRequestDto autor)
        {
            return await _repository.Update(autor);
          
        }
        
    }
}