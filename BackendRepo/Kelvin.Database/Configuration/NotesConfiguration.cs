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
    public class NotesConfiguration : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Keys)
                .HasMaxLength(4000);

            builder
                .Property(m => m.Name)
                .HasMaxLength(4000);

            builder
                .Property(m => m.DatesCreate)
                .HasColumnType("datetime");

            builder
                .HasMany(m => m.noteContent);

            builder
                .ToTable("Notes");
        }
    }
}
