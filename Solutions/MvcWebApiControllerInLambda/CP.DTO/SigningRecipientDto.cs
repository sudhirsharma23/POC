using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO
{
    public class SigningRecipientDto
    {
        public string ClientUserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }        
        public string RecipientId { get; set; }
        public string RoutingOrder { get; set; }        
        public SigningTabsDto Tabs { get; set; }
    }
}
