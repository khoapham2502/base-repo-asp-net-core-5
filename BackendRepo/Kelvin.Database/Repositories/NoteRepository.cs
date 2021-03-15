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
    public class NoteRepository : Repository<Notes>, INoteRepo
    {
        private MyNoteContext myNoteContext
        {
            get { return Context as MyNoteContext; }
        }

        public NoteRepository(MyNoteContext myNoteContext) : base(myNoteContext)
        {
        }

        public async Task<IEnumerable<Notes>> GetAllAsync()
        {
            return await myNoteContext.notes.Include(m => m.noteContent).ToListAsync();
        }

        public async Task<Notes> GetByIdAsync(int id)
        {
            return await myNoteContext.notes.Include(m => m.noteContent).FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
