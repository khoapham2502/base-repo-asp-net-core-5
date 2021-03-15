using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kelvin.Core.Model;
using Kelvin.Core.IModelRepo;
using Kelvin.Database.Repositories;
using Kelvin.Core;

namespace Kelvin.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyNoteContext _context;
        private INoteRepo _note;
        private INoteContentRepo _noteContent;
        private INoteContentFilesRepo _noteFiles;
        private bool disposedValue;

        public UnitOfWork(MyNoteContext context)
        {
            this._context = context;
        }

        INoteRepo IUnitOfWork.Note => _note = _note ?? new NoteRepository(_context);

        INoteContentRepo IUnitOfWork.NoteContent => _noteContent = _noteContent ?? new NoteContentRepository(_context);

        INoteContentFilesRepo IUnitOfWork.NoteFiles => _noteFiles = _noteFiles ?? new NoteContentFilesRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
