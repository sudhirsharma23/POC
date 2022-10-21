using CP.DTO;
using CP.DTO.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP.Core.User
{
    public interface IUserManager
    {
        Task<List<ConsumerFileDto>> GetConsumerDetailsByIdentity(string identity);

        Task<NotificationCount> GetUnreadNotificationCount(string identity);

        Task<NotificationCountDetails> GetCounts(int consumerFileId, string identity);

    }
}
