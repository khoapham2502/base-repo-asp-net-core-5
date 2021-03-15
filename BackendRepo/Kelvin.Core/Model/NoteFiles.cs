using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelvin.Core.Model
{
    public class NoteFiles
    {
        public NoteFiles()
        {

        }
        public int Id { get; set; }
        public int IdContent { get; set; }
        public string FileUrl { get; set; }
        public NoteContent noteContent { get; set; }
    }
}
