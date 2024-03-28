using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.DTOs.Request.Comics;

namespace Comics.DTOs.Request.Editora
{
    public class CreateEditoraRequestDto
    {
        public EditoraDTO? Editora { get; set; }
        public List<ComicDTO>? Comics { get; set; }
    }
}