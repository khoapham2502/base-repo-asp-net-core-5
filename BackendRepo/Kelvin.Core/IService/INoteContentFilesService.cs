using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kelvin.Core.Model;

namespace Kelvin.Core.IService
{
    public interface INoteContentFilesService
    {
        Task<IEnumerable<NoteFiles>> GetByConetntId(int Id);
    }
}
