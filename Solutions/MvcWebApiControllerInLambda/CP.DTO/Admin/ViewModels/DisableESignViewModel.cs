using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Admin.ViewModels
{
    public class DisableESignViewModel
    {

        public string FastEmail { get; set; }
        public string ConsumerName { get; set; }
        public int consumerFileID { get; set; }
        public int BuyerSellerTypeId { get; set; }
        public int ConsumerFilestatusId { get; set; }
        public bool PrimaryEsignDisabled { get; set; }
        public bool SecondaryEsignAvailable { get; set; }
        public bool SecondaryEsignDisabled { get; set; }
        public bool SecondaryEsignRemoved { get; set; }

    }
}
