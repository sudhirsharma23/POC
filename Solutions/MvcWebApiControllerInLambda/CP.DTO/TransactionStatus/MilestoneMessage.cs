using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    public class Messages
    {
        public string Consumer { get; set; }

        public string TaskState { get; set; }

        public string TaskType { get; set; }

        public string Description { get; set; }

        public int Active { get; set; }
        public ConsumerType ConsumerType
        {
            get
            {
                if (string.IsNullOrEmpty(this.Consumer))
                {
                    throw new Exception("Consumer Type can not be null");
                }
                //return CP.Infrastructure.Utils.EnumHelper.ToEnum<ConsumerType>(this.Consumer);
                return new ConsumerType();
            }
        }

        public bool IsActive
        {
            get
            {
                return Convert.ToBoolean(this.Active);
            }
        }

    }
    public class MilestoneMessage : Messages
    {
        public TransactionType TransactionType
        {
            get
            {
                if (string.IsNullOrEmpty(this.TaskType))
                {
                    throw new Exception("Task Type can not be null");
                }
                //return CP.Infrastructure.Utils.EnumHelper.ToEnum<TransactionType>(this.TaskType);
                return new TransactionType();
            }
        }

    }
    public class AgentMilestoneMessage : Messages
    {
        public AgentTransactionType AgentTransactionType
        {
            get
            {
                if (string.IsNullOrEmpty(this.TaskType))
                {
                    throw new Exception("Task Type can not be null");
                }
                //return CP.Infrastructure.Utils.EnumHelper.ToEnum<AgentTransactionType>(this.TaskType);
                return new AgentTransactionType();
            }
        }

    }
}
