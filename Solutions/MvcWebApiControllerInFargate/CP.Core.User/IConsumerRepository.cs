using CP.DTO;
using CP.DTO.ESigning;
using CP.DTO.Event;
using CP.DTO.TransactionStatus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP.Core.User
{
    public interface IConsumerRepository
    {
        Task<List<ConsumerFileDto>> GetConsumerFilesByIdentity(string identityId);

        Task<List<ConsumerFileDto>> GetCurrentInEligibleConsumers(int fastFileId, ConsumerType? consumerType);

        Task<UnreadDocAndMsgCount> GetUnreadDocAndMsgCount(int consumerFileId);

        Task<bool> SetUnreadDocAndMsgCount(int consumerFileId, CountNotificationType notificationType, bool docCount, bool msgCount, int? unreadDocCount, int? unreadMsgCount);
    }
}