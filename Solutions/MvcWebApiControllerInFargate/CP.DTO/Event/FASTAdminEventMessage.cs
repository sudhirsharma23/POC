using System;

namespace CP.DTO.Event
{
    public class FASTAdminEventMessage
    {
        public int FASTAdminEventsLogId { get; set; }
        //public int EventTypeId { get; set; }
        public string EventData { get; set; }
        public int EventStatusTypeId { get; set; }
        public string EventServer { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ProcessStartDate { get; set; }
        public DateTime? ProcessEndDate { get; set; }
        public string Comments { get; set; }
        public Guid ServiceGuid { get; set; }       
        public string ObjectCd { get; set; }
        public int RetryAttempts { get; set; }
        public int BizOrgId { get; set; }
        public int ContactId { get; set; }
    }
}
