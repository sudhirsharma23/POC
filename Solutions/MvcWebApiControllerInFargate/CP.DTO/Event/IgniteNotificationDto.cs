using System;

namespace CP.DTO.Event
{
    public class IgniteNotificationDto
    {
        public int Id { get; set; }  
        public int FastFileId { get; set; }
        public int IgniteFileId { get; set; }
        public string ObjectCd { get; set; }
        public string SubCodes { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public int TaskStatusId { get; set; }
        public string NotificationData { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ProcessStartDate { get; set; }
        public DateTime? ProcessEndDate { get; set; }
        public string Comments { get; set; }
        public string ResponseXml { get; set; }       
    }
}
