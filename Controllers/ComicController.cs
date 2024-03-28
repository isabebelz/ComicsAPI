using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comic;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicController : ControllerBase
    {
        private readonly IComicRepository _repository;
        public ComicController(IComicRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("CreateComic")]
        public async Task<ResponseGenericDTO> Create(CreateComicRequestDto comic)
        {
            return await _repository.Create(comic);
        }

        [HttpGet("ReadTodasComics")]
        public async Task<IEnumerable<dynamic>> Read()
        {
            return await _repository.Read();
        }

        [HttpGet("ReadComic/{id}")]
        public async Task<ActionResult<ComicDTO>> ReadId(int id)
        {
            var responseComic = await _repository.ReadId(id);

            if (responseComic != null) return Ok(responseComic);
            return NotFound();
        
        }

        [HttpDelete("DeleteComic")]
        public async Task<ResponseGenericDTO> Delete(int idComic)
        {
            return await _repository.Delete(idComic);
         
        }

        
        [HttpPatch("UpdateComic")]
        public async Task<ResponseGenericDTO> Update(UpdateComicRequestDto comic)
        {
            return await _repository.Update(comic);
          
        }
        
    }
}