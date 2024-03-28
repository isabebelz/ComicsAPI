using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Data;
using Comics.DTOs.Request.Autor;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Comics.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ComicContext _context;
        public AutorRepository(ComicContext context)
        {
            _context = context;
        }

        public async Task<ResponseGenericDTO> Create(CreateAutorRequestDto autor)
        {
            try
            {

                var createAutor = _context.Autores.Add(new Autor
                {
                    Nome = autor.Autor!.Nome
                });

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Autor criado com sucesso!"), Dado = createAutor.Entity };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Update(UpdateAutorRequestDto autor)
        {
            try
            {
                var autorExiste = await ReadId(autor.IdAutor);

                if (autorExiste == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Autor não encontrado!") };

                autorExiste.Nome = autor.Nome;

                _context.Autores.Update(autorExiste);
                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Atualizado com Sucesso!"), Dado = autorExiste };

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
                var autorExiste = await _context.Autores.FindAsync(id);

                if (autorExiste == null)
                {
                    return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Autor não encontrado!") };

                }

                _context.Autores.Remove(autorExiste);
                await _context.SaveChangesAsync();
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
                SELECT [IdAutor] AS IdAutor
                    ,[Nome] AS Nome
                FROM Autores";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryAsync(query.ToString());
                    return resultado;

                }

            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao ler os autores.", e);
            }

        }
        public async Task<Autor> ReadId(int id)
        {
            try
            {
                var query = @$"
                SELECT * FROM Autores WHERE IdAutor = {id}";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryFirstOrDefaultAsync<Autor>(query);
                    return resultado;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Ocorreu um erro ao tentar ler o autor", e);
            }

        }

    }
}