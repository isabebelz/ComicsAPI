using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;

namespace Comics.DTOs.Request.Editora
{
    public class UpdateEditoraRequestDto
    {
        public int IdEditora { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}