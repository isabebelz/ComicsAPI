using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Comics.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Comics.Data
{
    public class ComicContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public ComicContext(IConfiguration configuration, DbContextOptions<ComicContext> options)
            : base(options)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlServer");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        
        public DbSet<Comic> Comics { set; get; }
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionString = _configuration.GetConnectionString(typeDatabase);
            
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServer"),
            assembly => assembly.MigrationsAssembly(typeof(ComicContext).Assembly.FullName));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }


    }
}