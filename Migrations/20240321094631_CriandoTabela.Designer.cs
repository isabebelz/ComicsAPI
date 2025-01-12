﻿// <auto-generated />
using System;
using Comics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Comics.Migrations
{
    [DbContext(typeof(ComicContext))]
    [Migration("20240321094631_CriandoTabela")]
    partial class CriandoTabela
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistaPersonagem", b =>
                {
                    b.Property<int>("ArtistasIdArtista")
                        .HasColumnType("int");

                    b.Property<int>("PersonagensIdPersoangem")
                        .HasColumnType("int");

                    b.HasKey("ArtistasIdArtista", "PersonagensIdPersoangem");

                    b.HasIndex("PersonagensIdPersoangem");

                    b.ToTable("ArtistaPersonagem");
                });

            modelBuilder.Entity("AutorComic", b =>
                {
                    b.Property<int>("AutoresIdAutor")
                        .HasColumnType("int");

                    b.Property<int>("ComicsIdComic")
                        .HasColumnType("int");

                    b.HasKey("AutoresIdAutor", "ComicsIdComic");

                    b.HasIndex("ComicsIdComic");

                    b.ToTable("AutorComic");
                });

            modelBuilder.Entity("Comics.Model.Artista", b =>
                {
                    b.Property<int>("IdArtista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdArtista"));

                    b.Property<int?>("ComicIdComic")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdArtista");

                    b.HasIndex("ComicIdComic");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Comics.Model.Autor", b =>
                {
                    b.Property<int>("IdAutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAutor"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonagemIdPersoangem")
                        .HasColumnType("int");

                    b.HasKey("IdAutor");

                    b.HasIndex("PersonagemIdPersoangem");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("Comics.Model.Comic", b =>
                {
                    b.Property<int>("IdComic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdComic"));

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<int>("ComicStatus")
                        .HasColumnType("int");

                    b.Property<int>("IdEditora")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroEdicao")
                        .HasColumnType("int");

                    b.Property<string>("Sinopse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComic");

                    b.HasIndex("IdEditora");

                    b.ToTable("Comics");
                });

            modelBuilder.Entity("Comics.Model.Editora", b =>
                {
                    b.Property<int>("IdEditora")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEditora"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEditora");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("Comics.Model.Equipe", b =>
                {
                    b.Property<int>("IdEquipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEquipe"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEquipe");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("Comics.Model.Personagem", b =>
                {
                    b.Property<int>("IdPersoangem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPersoangem"));

                    b.Property<int?>("ComicIdComic")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habilidades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPersoangem");

                    b.HasIndex("ComicIdComic");

                    b.ToTable("Personagens");
                });

            modelBuilder.Entity("EquipePersonagem", b =>
                {
                    b.Property<int>("EquipesIdEquipe")
                        .HasColumnType("int");

                    b.Property<int>("MembrosIdPersoangem")
                        .HasColumnType("int");

                    b.HasKey("EquipesIdEquipe", "MembrosIdPersoangem");

                    b.HasIndex("MembrosIdPersoangem");

                    b.ToTable("EquipePersonagem");
                });

            modelBuilder.Entity("PersonagemPersonagem", b =>
                {
                    b.Property<int>("AliadosIdPersoangem")
                        .HasColumnType("int");

                    b.Property<int>("InimigosIdPersoangem")
                        .HasColumnType("int");

                    b.HasKey("AliadosIdPersoangem", "InimigosIdPersoangem");

                    b.HasIndex("InimigosIdPersoangem");

                    b.ToTable("PersonagemPersonagem");
                });

            modelBuilder.Entity("ArtistaPersonagem", b =>
                {
                    b.HasOne("Comics.Model.Artista", null)
                        .WithMany()
                        .HasForeignKey("ArtistasIdArtista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comics.Model.Personagem", null)
                        .WithMany()
                        .HasForeignKey("PersonagensIdPersoangem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutorComic", b =>
                {
                    b.HasOne("Comics.Model.Autor", null)
                        .WithMany()
                        .HasForeignKey("AutoresIdAutor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comics.Model.Comic", null)
                        .WithMany()
                        .HasForeignKey("ComicsIdComic")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Comics.Model.Artista", b =>
                {
                    b.HasOne("Comics.Model.Comic", null)
                        .WithMany("Artistas")
                        .HasForeignKey("ComicIdComic");
                });

            modelBuilder.Entity("Comics.Model.Autor", b =>
                {
                    b.HasOne("Comics.Model.Personagem", null)
                        .WithMany("Autores")
                        .HasForeignKey("PersonagemIdPersoangem");
                });

            modelBuilder.Entity("Comics.Model.Comic", b =>
                {
                    b.HasOne("Comics.Model.Editora", "Editora")
                        .WithMany("Comics")
                        .HasForeignKey("IdEditora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editora");
                });

            modelBuilder.Entity("Comics.Model.Personagem", b =>
                {
                    b.HasOne("Comics.Model.Comic", null)
                        .WithMany("Personagens")
                        .HasForeignKey("ComicIdComic");
                });

            modelBuilder.Entity("EquipePersonagem", b =>
                {
                    b.HasOne("Comics.Model.Equipe", null)
                        .WithMany()
                        .HasForeignKey("EquipesIdEquipe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comics.Model.Personagem", null)
                        .WithMany()
                        .HasForeignKey("MembrosIdPersoangem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonagemPersonagem", b =>
                {
                    b.HasOne("Comics.Model.Personagem", null)
                        .WithMany()
                        .HasForeignKey("AliadosIdPersoangem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Comics.Model.Personagem", null)
                        .WithMany()
                        .HasForeignKey("InimigosIdPersoangem")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Comics.Model.Comic", b =>
                {
                    b.Navigation("Artistas");

                    b.Navigation("Personagens");
                });

            modelBuilder.Entity("Comics.Model.Editora", b =>
                {
                    b.Navigation("Comics");
                });

            modelBuilder.Entity("Comics.Model.Personagem", b =>
                {
                    b.Navigation("Autores");
                });
#pragma warning restore 612, 618
        }
    }
}
