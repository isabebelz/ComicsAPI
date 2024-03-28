using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Request.Equipe;

namespace Comics.DTOs.Request.Personagem
{
    public class CreatePersonagemRequestDto
    {
        public PersonagemDTO? Personagem { get; set; }
        public ICollection<AutorDTO>? Autores { get; set; }
        public ICollection<ArtistaDTO>? Artistas { get; set; }
        public ICollection<PersonagemDTO>? Aliados { get; set; } 
        public ICollection<PersonagemDTO>? Inimigos { get; set; } 
        public ICollection<EquipeDTO>? Equipes { get; set; }
    }


}