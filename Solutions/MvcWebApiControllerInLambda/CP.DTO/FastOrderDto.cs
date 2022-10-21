using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.DTO.FastFileData;
namespace CP.DTO
{
    public class FastOrderDto
    {
        public FileInfoDto FileInfo { get; set; }

        public Order OrderInfo { get; set; }
    }
}
