using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comic;
using Comics.DTOs.Request.Equipe;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeRepository _repository;

        public EquipeController(IEquipeRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateEquipe")]
        public async Task<ResponseGenericDTO> Create(CreateEquipeRequestDto equipe)
        {
            return await _repository.Create(equipe);
        }

        [HttpGet("ReadTodasEquipes")]
        public async Task<IEnumerable<dynamic>> Read()
        {
            return await _repository.Read();
        }

       [HttpGet("ReadEquipe/{id}")]
        public async Task<ActionResult<EquipeDTO>> ReadId(int id)
        {
            var responseEquipe = await _repository.ReadId(id);

            if (responseEquipe != null) return Ok(responseEquipe);
            return NotFound();
        
        }

        [HttpPatch("UpdateEquipe")]
        public async Task<ResponseGenericDTO> Update(UpdateEquipeRequestDto equipe)
        {
            return await _repository.Update(equipe);
          
        }

        [HttpDelete("DeleteEquipe")]
        public async Task<ResponseGenericDTO> Delete(int idEquipe)
        {
            return await _repository.Delete(idEquipe);
         
        }

        
        
    }
}