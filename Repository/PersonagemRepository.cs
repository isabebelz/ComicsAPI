using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Data;
using Comics.DTOs.Request.Personagem;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Comics.Repository
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly ComicContext _context;
        

        public PersonagemRepository(ComicContext context)
        {
            _context = context;
        }

        public async Task<ResponseGenericDTO> Create(CreatePersonagemRequestDto personagem)
        {
            try
            {

                var createPersonagem = _context.Personagens.Add(new Personagem
                {
                    Nome = personagem.Personagem!.Nome,
                    Identidade = personagem.Personagem!.Identidade,
                    Origem = personagem.Personagem!.Origem,
                    Habilidades = personagem.Personagem!.Habilidades,
                    Descricao = personagem.Personagem!.Descricao
                });

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Personagem criado com sucesso!"), Dado = createPersonagem.Entity };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Update(UpdatePersonagemRequestDto personagem)
        {
            try
            {
                var personagemExiste = await ReadId(personagem.IdPersoangem);

                if (personagemExiste == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Personagem não encontrado!") };

                personagemExiste.Nome = personagem.Nome;
                personagemExiste.Identidade = personagem.Identidade;
                personagemExiste.Origem = personagem.Origem;
                personagemExiste.Descricao = personagem.Descricao;
                personagemExiste.Habilidades = personagem.Habilidades;

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Atualizado com Sucesso!"), Dado = personagemExiste };

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
                var personagem = ReadId(id).Result;

                if (personagem == null)
                {
                    if (personagem == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Personagem não encontrado!") };

                }

                _context.Personagens.Remove(personagem);
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
                SELECT [IdPersonagem] AS IdPersonagem
                    ,[Nome] AS Nome
                    ,[Identidade] AS Identidade
                    ,[Origem] AS Origem
                    ,[Descricao] AS Descricao
                    ,[Habilidades] AS Habilidades
                FROM Personagens";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryAsync(query.ToString());
                    return resultado;

                }

            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao ler os personagens.", e);
            }

        }
        public async Task<Personagem> ReadId(int id)
        {
            var query = @$"
                SELECT * FROM Personagens WHERE Id = @Id";

            using(var connection = _context.CreateConnection())
            {
                var resultado = await connection.QueryFirstAsync<Personagem>(query);
                return resultado;
            }

        }

    }
}