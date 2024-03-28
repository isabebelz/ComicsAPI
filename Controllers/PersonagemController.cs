using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Request.Personagem;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonagemController : ControllerBase
    {
        private readonly IPersonagemRepository _repository;

        public PersonagemController(IPersonagemRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreatePersonagem")]
        public async Task<ResponseGenericDTO> Create(CreatePersonagemRequestDto personagem)
        {
            return await _repository.Create(personagem);
        }

        [HttpGet("ReadTodosPersonagens")]
        public async Task<IEnumerable<dynamic>> Read()
        {
            return await _repository.Read();
        }

       [HttpGet("ReadPersonagem/{id}")]
        public async Task<ActionResult<PersonagemDTO>> ReadId(int id)
        {
            var responsePersonagem = await _repository.ReadId(id);

            if (responsePersonagem != null) return Ok(responsePersonagem);
            return NotFound();
        
        }

        [HttpPatch("UpdatePersonagem")]
        public async Task<ResponseGenericDTO> Update(UpdatePersonagemRequestDto personagem)
        {
            return await _repository.Update(personagem);
          
        }

        [HttpDelete("DeletePersonagem")]
        public async Task<ResponseGenericDTO> Delete(int idPersonagem)
        {
            return await _repository.Delete(idPersonagem);
         
        }

        

        
    }
}