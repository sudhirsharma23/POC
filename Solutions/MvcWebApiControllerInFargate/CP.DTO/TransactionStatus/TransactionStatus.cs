using System;
using System.ComponentModel.DataAnnotations;

namespace CP.DTO.TransactionStatus
{
    public class TransactionStatus
    {
        public TransactionStatus()
        {
            this.Type = TransactionType.OrderReceivedFromLender;
        }
        //public string DisplayName
        //{
        //    get
        //    {
        //        return this.Type.GetAttribute<DisplayAttribute>().Name;
        //    }
        //}

        //public int DisplayOrder
        //{
        //    get
        //    {
        //        return this.Type.GetAttribute<DisplayAttribute>().Order;
        //    }
        //}
        public TransactionType Type { get; set; }

        public TransactionStateType Status { get; set; }

        public string Verbiage { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsDefault { get; set; }
    }

    public class AgentTransactionStatus
    {
        public AgentTransactionStatus()
        {
            this.Type = AgentTransactionType.BuyerEmailPhoneCollected;
        }
        //public string DisplayName
        //{
        //    get
        //    {
        //        return this.Type.GetAttribute<DisplayAttribute>().Name;
        //    }
        //}

        //public int DisplayOrder
        //{
        //    get
        //    {
        //        return this.Type.GetType().AttributesGetAttribute<DisplayAttribute>().Order;
        //    }
        //}
        public AgentTransactionType Type { get; set; }

        public TransactionStateType Status { get; set; }

        public string Verbiage { get; set; }

        public DateTime? CompletedDate { get; set; }

        public bool IsDefault { get; set; }
    }
}
