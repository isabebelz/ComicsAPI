using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.DTOs.Request.Artista
{
    public class UpdateArtistaRequestDto
    {
        public int IdArtista { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}