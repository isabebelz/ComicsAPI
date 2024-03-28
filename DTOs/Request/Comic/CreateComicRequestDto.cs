using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Enum;
using Comics.Model;

namespace Comics.DTOs.Request.Comics
{
    public class CreateComicRequestDto
    {
        public ComicDTO? Comic { get; set; }
        public List<PersonagemDTO>? Personagens { get; set; }
        public List<ArtistaDTO>? Artistas { get; set; }
        public List<AutorDTO>? Autores { get; set; }
        public EditoraDTO? Editora { get; set; }

    }

    public class ComicDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int NumeroEdicao { get; set; }
        public int AnoLancamento { get; set; }
        public ComicStatus ComicStatus { get; set; }
        public string Sinopse { get; set; } = string.Empty;
    }

    public class PersonagemDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Identidade { get; set; } = string.Empty;
        public string Origem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Habilidades { get; set; } = string.Empty;
    }

    public class ArtistaDTO
    {
        public string Nome { get; set; } = string.Empty;
    }

    public class AutorDTO
    {
        public string Nome { get; set; } = string.Empty;
    }

    public class EditoraDTO
    {
        public string Nome { get; set; } = string.Empty;
    }
}