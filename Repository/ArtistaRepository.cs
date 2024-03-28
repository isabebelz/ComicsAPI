using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Data;
using Comics.DTOs.Request.Artista;
using Comics.DTOs.Response.Generic;
using Comics.Model;
using Comics.Repository.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comics.Repository
{
    public class ArtistaRepository : IArtistaRepository
    {
        private readonly ComicContext _context;


        public ArtistaRepository(ComicContext context)
        {
            _context = context;
        }

        public async Task<ResponseGenericDTO> Create(CreateArtistaRequestDto artista)
        {
            try
            {

                var createArtista = _context.Artistas.Add(new Artista
                {
                    Nome = artista.Artista!.Nome
                });

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Artista criado com sucesso!"), Dado = createArtista.Entity };
            }
            catch (Exception e)
            {
                return new ResponseGenericDTO() { Resposta = new ResponseDTO() { StatusCode = StatusCodes.Status500InternalServerError, Message = $"Erro: {e.Message}" } };

            }

        }

        public async Task<ResponseGenericDTO> Update(UpdateArtistaRequestDto artista)
        {
            try
            {
                var artistaExiste = await ReadId(artista.IdArtista);

                if (artistaExiste == null) return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Artista não encontrado!") };

                artistaExiste.Nome = artista.Nome;

                await _context.SaveChangesAsync();
                return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status200OK, "Atualizado com Sucesso!"), Dado = artistaExiste };

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
                var artistaExiste = await _context.Artistas.FindAsync(id);

                if (artistaExiste == null)
                {
                    return new ResponseGenericDTO() { Resposta = new ResponseDTO(StatusCodes.Status404NotFound, "Artista não encontrado!") };

                }

                _context.Artistas.Remove(artistaExiste);
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
                SELECT [IdArtista] AS IdArtista
                    ,[Nome] AS Nome
                FROM Artistas";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryAsync(query.ToString());
                    return resultado;

                }

            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao ler os artistas.", e);
            }

        }
        public async Task<Artista> ReadId(int id)
        {

            try
            {
                
                var query = @$"
                SELECT * FROM Artistas WHERE IdArtista = {id}";

                using (var connection = _context.CreateConnection())
                {
                    var resultado = await connection.QueryFirstOrDefaultAsync<Artista>(query.ToString());
                    return resultado;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao ler os artistas.", e);
            }

        }

    }
}