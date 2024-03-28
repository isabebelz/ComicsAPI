using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;

namespace Comics.DTOs.Request.Artista
{
    public class CreateArtistaRequestDto
    {
        public ArtistaDTO? Artista { get; set; }
        public List<PersonagemDTO>? Personagens { get; set; }
    }
}