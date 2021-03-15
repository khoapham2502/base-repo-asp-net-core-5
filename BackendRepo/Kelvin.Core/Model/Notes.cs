using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelvin.Core.Model
{
    public class Notes
    {
        public Notes()
        {
            noteContent = new Collection<NoteContent>();
        }
        public int Id { get; set; }
        public string Keys { get; set; }
        public string Name { get; set; }
        public DateTime DatesCreate { get; set; }
        public ICollection<NoteContent> noteContent { get; set; }
    }
}
