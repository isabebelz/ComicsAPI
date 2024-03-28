using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Data;
using Comics.DTOs.Request.Comic;
using Comics.DTOs.Request.Comics;
using Comics.DTOs.Request.Equipe;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Dapper;

namespace Comics.Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly ComicContext _context;

        public EquipeRepository(ComicContext context)
        {
            _context = context;
        }

        public async Task<ResponseGenericDTO> Create(CreateEquipeRequestDto equipe)
        {
            try
            {

                var createEquipe = _context.Equipes.Add(new Equipe
                {
                    Nome = equipe.Equipe!.Nome
                });

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Equipe criada com sucesso!"), Dado = createEquipe.Entity };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Update(UpdateEquipeRequestDto equipe)
        {
            try
            {
                var equipeExiste = await ReadId(equipe.IdEquipe);

                if (equipeExiste == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Equipe não encontrada!") };

                equipeExiste.Nome = equipe.Nome;

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Atualizado com Sucesso!"), Dado = equipeExiste };

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
                var equipe = ReadId(id).Result;

                if (equipe == null)
                {
                    if (equipe == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Equipe não encontrada!") };

                }

                _context.Equipes.Remove(equipe);
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
                SELECT [IdEquipe] AS IdEquipe
                    ,[Nome] AS Nome
                FROM Equipes ";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryAsync(query.ToString());
                    return resultado;

                }

            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao ler os comunicado.", e);
            }

        }
        public async Task<Equipe> ReadId(int id)
        {
            var query = @$"
                SELECT * FROM Equipe WHERE Id = @Id";

            using(var connection = _context.CreateConnection())
            {
                var resultado = await connection.QueryFirstAsync<Equipe>(query);
                return resultado;
            }

        }

    }
}