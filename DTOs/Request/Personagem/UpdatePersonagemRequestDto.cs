using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comics.DTOs.Request.Personagem
{
    public class UpdatePersonagemRequestDto
    {
        public int IdPersoangem { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Identidade { get; set; } = string.Empty;
        public string Origem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Habilidades { get; set; } = string.Empty;
    }
}