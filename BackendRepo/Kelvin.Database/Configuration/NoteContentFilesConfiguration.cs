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
    public class NoteContentFilesConfiguration : IEntityTypeConfiguration<NoteFiles>
    {
        void IEntityTypeConfiguration<NoteFiles>.Configure(EntityTypeBuilder<NoteFiles> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FileUrl)
                .HasMaxLength(4000);

            builder
                .HasOne(m => m.noteContent)
                .WithMany(m => m.noteFiles)
                .HasForeignKey(m => m.IdContent)
                .HasConstraintName("FK_NoteFiles_NoteContent");

            builder
                .ToTable("NoteFiles");
        }
    }
}
