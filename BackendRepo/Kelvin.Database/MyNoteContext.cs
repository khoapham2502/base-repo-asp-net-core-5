using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kelvin.Core.Model;
using Kelvin.Database.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Kelvin.Database
{
    public class MyNoteContext : DbContext
    {
        public DbSet<Notes> notes { get; set; }
        public DbSet<NoteContent> noteContent { get; set; }
        public DbSet<NoteFiles> noteFiles { get; set; }

        public MyNoteContext(DbContextOptions<MyNoteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new NoteContentConfiguration());

            builder
                .ApplyConfiguration(new NoteContentConfiguration());

            builder
                .ApplyConfiguration(new NoteContentFilesConfiguration());
        }
    }
}
