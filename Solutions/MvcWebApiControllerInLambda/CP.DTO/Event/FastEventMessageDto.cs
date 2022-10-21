using System;

namespace CP.DTO.Event
{
    public class FASTEventMessageDto
    {
        public int FASTEventsDataLogId { get; set; }
        //public int EventTypeId { get; set; }
        public string EventData { get; set; }
        public int EventStatusTypeId { get; set; }
        public string EventServer { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ProcessStartDate { get; set; }
        public DateTime? ProcessEndDate { get; set; }
        public string Comments { get; set; }
        public Guid ServiceGuid { get; set; }
        public string ResponseXml { get; set; }
        public int FileId { get; set; }
        public string ObjectCd { get; set; }
        public string SubCodes { get; set; }
    }
}
