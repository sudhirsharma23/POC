using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Branding
{
    public class Brand
    {
        public int Id { get; set; }
        public string LogoUri { get; set; }
        public string MessageTag { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CssClass { get; set; }
        public string CompanyName1 { get; set; }
        public string CompanyName2 { get; set; }
        public string DocumentName { get; set; }
        public string ExcludeDocument { get; set; }
        public string WidgetHeader { get; set; }
    }


}
