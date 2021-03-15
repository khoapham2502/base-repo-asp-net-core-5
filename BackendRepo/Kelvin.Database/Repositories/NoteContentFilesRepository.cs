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
    class NoteContentFilesRepository : Repository<NoteFiles>, INoteContentFilesRepo
    {
        private MyNoteContext myNoteContext
        {
            get { return Context as MyNoteContext; }
        }

        public NoteContentFilesRepository(MyNoteContext myNoteContext) : base(myNoteContext)
        {
        }

        public async Task<IEnumerable<NoteFiles>> GetAllAsync()
        {
            return await myNoteContext.noteFiles.ToListAsync();
        }

        public async Task<NoteFiles> GetByIdAsync(int id)
        {
            return await myNoteContext.noteFiles.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
