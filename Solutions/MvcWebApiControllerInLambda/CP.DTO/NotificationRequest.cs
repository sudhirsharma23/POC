using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class NotificationRequest
    {
        public DateTime DateTime { get; set; }
        public string TrackingID { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string ObjectCd { get; set; }
        public List<Detail> Details { get; set; }
        public List<Field> Fields { get; set; }
    }
    public class Detail
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Field
    {
        public string FieldObjectCd { get; set; }
    }
}
