using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Request.Editora;
using Comics.DTOs.Response.Generic;
using Comics.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraRepository _repository;

        public EditoraController(IEditoraRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost("CreateEditora")]
        public async Task<ResponseGenericDTO> Create(CreateEditoraRequestDto editora)
        {
            return await _repository.Create(editora);
        }

        [HttpGet("ReadTodasEditoras")]
        public async Task<IEnumerable<dynamic>> Read()
        {
            return await _repository.Read();
        }

        [HttpGet("ReadEditora/{id}")]
        public async Task<ActionResult<EditoraDTO>> ReadId(int id)
        {
            var responseEditora = await _repository.ReadId(id);

            if (responseEditora != null) return Ok(responseEditora);
            return NotFound();
        
        }
        
        [HttpDelete("UpdateEditora")]
        public async Task<ResponseGenericDTO> Update(UpdateEditoraRequestDto editora)
        {
            return await _repository.Update(editora);
          
        }

        [HttpPatch("DeleteEditora")]
        public async Task<ResponseGenericDTO> Delete(int idEditora)
        {
            return await _repository.Delete(idEditora);
         
        }

        
    }
}