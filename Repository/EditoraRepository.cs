using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Data;
using Comics.DTOs.Request.Editora;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Dapper;

namespace Comics.Repository
{
    public class EditoraRepository : IEditoraRepository
    {
        private readonly ComicContext _context;

        public EditoraRepository(ComicContext context)
        {
            _context = context;
        }

        public async Task<ResponseGenericDTO> Create(CreateEditoraRequestDto editora)
        {
            try
            {

                var createEditora = _context.Editoras.Add(new Editora
                {
                    Nome = editora.Editora!.Nome
                });

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Editora criado com sucesso!"), Dado = createEditora.Entity };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Update(UpdateEditoraRequestDto editora)
        {
            try
            {
                var editoraExiste = await ReadId(editora.IdEditora);

                if (editoraExiste == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Editora não encontrado!") };

                editoraExiste.Nome = editora.Nome;

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Atualizado com Sucesso!"), Dado = editoraExiste };

            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Delete(int id)
        {
            try
            {
                var editora = ReadId(id).Result;

                if (editora == null)
                {
                    if (editora == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Editora não encontrada!") };

                }

                _context.Editoras.Remove(editora);
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Deletado com Sucesso!") };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }



        }

        public async Task<IEnumerable<dynamic>> Read()
        {
            try
            {
                var query = @$"
                SELECT [IdEditora] AS IdEditora
                    ,[Nome] AS Nome
                FROM Editoras";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryAsync(query.ToString());
                    return resultado;

                }

            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao ler as editoras.", e);
            }

        }
        public async Task<Editora> ReadId(int id)
        {
            var query = @$"
                SELECT * FROM Editoras WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var resultado = await connection.QueryFirstAsync<Editora>(query);
                return resultado;
            }

        }


    }
}