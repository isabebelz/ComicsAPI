using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.DTOs.Request.Equipe
{
    public class UpdateEquipeRequestDto
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}