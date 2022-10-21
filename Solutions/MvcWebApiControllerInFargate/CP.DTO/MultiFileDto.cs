using CP.DTO.FastFileData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class MultiFileDto
    {
        public virtual Address Address { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime EstimatedClose { get; set; }

        public string Role { get; set; }
       


        }
}
