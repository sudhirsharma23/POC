using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CP.DTO.Ignite
{
    [DataContract]
    public class IgniteNotification
    {
        [DataMember]
        public int FastFileId { get; set; }
        [DataMember]
        public int IgniteFileId { get; set; }
        [DataMember]
        public string ObjectCd { get; set; }
        [DataMember]
        public string FieldObjectCd { get; set; }
        [DataMember]
        public NotificationData NotificationData { get; set; }
        [DataMember]
        public string Source { get; set; }
    }
  
    [DataContract]
    public class NotificationData
    {
        [DataMember]
        public long FileTaskId { get; set; }
        [DataMember]
        public int? TaskId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string DisplayName { get; set; }
        [DataMember]
        public DateTime? CompletedDate { get; set; }
        [DataMember]
        public DateTime? InProcessDate { get; set; }
        [DataMember]
        public DateTime? DueDate { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime? UpdatedDate { get; set; }
        [DataMember]
        public DateTime? WaivedDate { get; set; }
        [DataMember]
        public string TaskStatus { get; set; }
        [DataMember]
        public string TaskAction { get; set; }
        [DataMember]
        public string Comments { get; set; }
        [DataMember]
        public string Notes { get; set; }
    }
}
