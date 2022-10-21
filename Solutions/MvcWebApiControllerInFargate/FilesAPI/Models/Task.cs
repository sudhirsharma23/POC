using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAPI
{
    public class Task
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; }
        public DateTime DateModified { get; set; }
    }
}
