using System;

namespace CP.DTO
{
    public class IdentityLinkDetail
    {
        public Guid IdentityId { get; set; }
        public bool LinkingAttempted { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
