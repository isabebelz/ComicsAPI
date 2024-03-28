using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comics.Enum;
using Comics.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Comics.Map
{
    /*public class ComicMap : IEntityTypeConfiguration<Comic>
    {
        public void Configure(EntityTypeBuilder<Comic> builder)
        {
            builder.ToTable("comics");

            builder.HasKey(x => x.IdComic);

            builder.Property(x => x.Nome).HasMaxLength(40).IsRequired();
            builder.Property(x => x.NumeroEdicao).HasAnnotation("MinValue", 1).IsRequired();
            builder.Property(x => x.AnoLancamento).HasAnnotation("MaxValue", 2000).IsRequired();
            builder.Property(x => x.Sinopse).IsRequired();
            builder.Property(x => x.ComicStatus).HasConversion(new EnumToStringConverter<ComicStatus>()).IsRequired();

            builder.Property(x => x.IdEditora);
            builder.HasOne(x => x.Editora).WithMany(x => x.Comics).HasForeignKey(x => x.IdEditora);

            builder.HasMany(x => x.Personagens)
                .WithMany(x => x.Comics)
                .UsingEntity<ComicPersonagem>(
                    x => x.HasOne(p => p.Comic).WithMany().HasForeignKey(x => x.IdComic),
                    x => x.HasOne(p => p.Personagem).WithMany().HasForeignKey(x => x.IdPersoangem),
                    x => 
                    {
                        x.ToTable("tb_comic_personagem");

                        x.HasKey(p => new {p.IdComic, p.IdPersoangem});

                        x.Property(p => p.IdComic).IsRequired();
                        x.Property(p => p.IdPersoangem).IsRequired();
                    }

                );





        }

    }*/
}