using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Data;
using Comics.DTOs.Request.Comic;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Dapper;

namespace Comics.Repository
{
    public class ComicRepository :IComicRepository
    {
        private readonly ComicContext _context;

        public ComicRepository(ComicContext context)
        {
            _context = context;
        }

        public async Task<ResponseGenericDTO> Create(CreateComicRequestDto comic)
        {
            try
            {

                var createComic = _context.Comics.Add(new Comic
                {
                    Nome = comic.Comic!.Nome,
                    NumeroEdicao = comic.Comic!.NumeroEdicao,
                    AnoLancamento = comic.Comic!.AnoLancamento,
                    ComicStatus = comic.Comic!.ComicStatus,
                    Sinopse = comic.Comic!.Sinopse

                });

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Comic criada com sucesso!"), Dado = createComic.Entity };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Update(UpdateComicRequestDto comic)
        {
            try
            {
                var comicExiste = await ReadId(comic.IdComic);

                if (comicExiste == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Comic não encontrado!") };

                comicExiste.Nome = comic.Nome;
                comicExiste.AnoLancamento = comic.AnoLancamento;
                comicExiste.NumeroEdicao = comic.NumeroEdicao;
                comicExiste.ComicStatus = comic.ComicStatus;
                comicExiste.Sinopse = comic.Sinopse;

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Atualizado com Sucesso!"), Dado = comicExiste };

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
                var comic = ReadId(id).Result;

                if (comic == null)
                {
                    if (comic == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Comic não encontrada!") };

                }

                _context.Comics.Remove(comic);
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
        public async Task<Comic> ReadId(int id)
        {
            var query = @$"
                SELECT * FROM Editoras WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var resultado = await connection.QueryFirstAsync<Comic>(query);
                return resultado;
            }

        }

        
        
    }
}