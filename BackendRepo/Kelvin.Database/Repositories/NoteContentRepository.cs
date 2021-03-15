using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kelvin.Core.IModelRepo;
using Kelvin.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Kelvin.Database.Repositories
{
    public class NoteContentRepository : Repository<NoteContent>, INoteContentRepo
    {
        private MyNoteContext myNoteContext
        {
            get { return Context as MyNoteContext; }
        }

        public NoteContentRepository(MyNoteContext myNoteContext) : base(myNoteContext)
        {
        }

        public async Task<IEnumerable<NoteContent>> GetAllAsync()
        {
            return await myNoteContext.noteContent.Include(m => m.noteFiles).ToListAsync();
        }

        public async Task<NoteContent> GetByIdAsync(int id)
        {
            return await myNoteContext.noteContent.Include(m => m.noteFiles).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
