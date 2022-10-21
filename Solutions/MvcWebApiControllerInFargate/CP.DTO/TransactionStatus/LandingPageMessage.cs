using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    public class LandingPageMessage
    {
        public LandingPageMessageType Type
        {
            get
            {
                if (TypeId == 0)
                {
                    throw new Exception("Type id is not defined");
                }
                return (LandingPageMessageType)TypeId;
            }
            set { }
        }
        public LandingPageMessageType MessageType
        { get; set; }

        public bool IsActive { get; set; }

        public int TypeId { get; set; }

        public string Description { get; set; }

    }
}
