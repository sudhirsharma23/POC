using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.Messaging
{
    public class ReminderMessage
    {
        public ReminderNotificationType Type
        {
            get
            {
                return (ReminderNotificationType)NotificationTypeId;
            }
        }
        public int NotificationTypeId { get; set; }
        public string Body { get; set; }

        public string Subject { get; set; }

        public int FileStatus { get; set; }

        public ConsumerFileStatus ConsumerFileStatus
        {
            get
            {
                return (ConsumerFileStatus)FileStatus;
            }
        }

    }
}
