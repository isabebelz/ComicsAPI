using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;

namespace Comics.DTOs.Request.Equipe
{
    public class CreateEquipeRequestDto
    {
        public EquipeDTO? Equipe { get; set; }
        public List<PersonagemDTO>? Personagens { get; set; }
    }

    public class EquipeDTO
    {
        public string Nome { get; set; } = string.Empty;
    }
}