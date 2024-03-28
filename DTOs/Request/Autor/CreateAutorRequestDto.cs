using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;

namespace Comics.DTOs.Request.Autor
{
    public class CreateAutorRequestDto
    {
        public AutorDTO? Autor { get; set; }
        public List<ComicDTO>? Comics { get; set; }
    }
}