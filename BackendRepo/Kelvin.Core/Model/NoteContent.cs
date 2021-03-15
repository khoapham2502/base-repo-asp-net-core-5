using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelvin.Core.Model
{
    public class NoteContent
    {
        public NoteContent()
        {
            noteFiles = new Collection<NoteFiles>();
        }
        public int Id { get; set; }
        public int IdNote { get; set; }
        public string Contents { get; set; }
        public Notes notes { get; set; }
        public ICollection<NoteFiles> noteFiles { get; set; }
    }
}
