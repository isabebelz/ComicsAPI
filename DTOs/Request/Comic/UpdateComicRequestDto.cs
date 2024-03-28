using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Enum;

namespace Comics.DTOs.Request.Comic
{
    public class UpdateComicRequestDto
    {
        public int IdComic { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int NumeroEdicao { get; set; }
        public int AnoLancamento { get; set; }
        public ComicStatus ComicStatus { get; set; }
        public string Sinopse { get; set; } = string.Empty;
    }
}