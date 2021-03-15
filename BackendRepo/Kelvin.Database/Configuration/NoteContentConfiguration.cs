using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kelvin.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kelvin.Database.Configuration
{
    public class NoteContentConfiguration : IEntityTypeConfiguration<NoteContent>
    {
        public void Configure(EntityTypeBuilder<NoteContent> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Contents)
                .HasMaxLength(4000);

            builder
                .HasOne(m => m.notes)
                .WithMany(m => m.noteContent)
                .HasForeignKey(m => m.IdNote)
                .HasConstraintName("FK_NoteContent_Notes");

            builder
                .HasMany(m => m.noteFiles);

            builder
                .ToTable("NoteContent");
        }
    }
}
