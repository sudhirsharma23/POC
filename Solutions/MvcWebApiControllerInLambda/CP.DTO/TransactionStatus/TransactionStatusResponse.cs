using System.Collections.Generic;

namespace CP.DTO.TransactionStatus
{
    public class TransactionStatusResponse
    {
        public List<TransactionStatus> Statuses { get; set; }
        public string Version { get; set; }
    }

    public class AgentTransactionStatusResponse
    {
        public List<AgentTransactionStatus> Statuses { get; set; }
    }

}
