using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kelvin.Core.IModelRepo;

namespace Kelvin.Core
{
    public interface IUnitOfWork : IDisposable
    {
        INoteRepo Note { get; }
        INoteContentRepo NoteContent { get; }
        INoteContentFilesRepo NoteFiles { get; }
        Task<int> CommitAsync();
    }
}
