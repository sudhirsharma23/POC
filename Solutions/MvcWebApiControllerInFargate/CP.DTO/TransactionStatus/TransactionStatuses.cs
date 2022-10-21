using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    public class TransactionStatuses<TTransactionStatus>
            where TTransactionStatus : class
    {
        public List<TTransactionStatus> Statuses { get; set; }

        public int ConsumerFileId { get; set; }

        public DateTime UpdatedDate { get; set; }

        public TransactionStatusesState State { get; set; }

        public byte[] Version { get; set; }

        #region Ctor
        public TransactionStatuses()
        {
            Statuses = new List<TTransactionStatus>();
        }
        #endregion
    }

    public enum TransactionStatusesState
    {
        Current,
        Updating
    }
}
