using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kelvin.Core;
using Kelvin.Core.IService;
using Kelvin.Core.Model;
using Kelvin.Database;
using Microsoft.EntityFrameworkCore;

namespace Kelvin.Service
{
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public NoteService(IUnitOfWork iUnitOfWork)
        {
            _unitOfWork = iUnitOfWork;
        }

        public async Task<IEnumerable<Notes>> GetByIdRange(int IdFrom, int IdTo)
        {
            return await (_unitOfWork.Note.GetAllAsync());
        }
    }
}
