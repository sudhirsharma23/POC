using CP.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CP.Core.User.Impl
{
    public class ConsumerRepository : IConsumerRepository
    {
        public async Task<List<ConsumerFileDto>> GetConsumerFilesByIdentity(string identityId)
        {
            return await Task.Run(() => { return Mock.GetConsumerFileDtoList(); });
        }

        public async Task<List<ConsumerFileDto>> GetCurrentInEligibleConsumers(int fastFileId, ConsumerType? consumerType)
        {
            return await Task.Run(() => { return Mock.GetConsumerFileDtoList(); });
        }

        public async Task<UnreadDocAndMsgCount> GetUnreadDocAndMsgCount(int consumerFileId)
        {
            var countObj = new UnreadDocAndMsgCount
            {
                UnreadDocCount = 1,
                Success = true,
                UnreadMsgCount = 1
            };

            return await Task.Run(() => { return countObj; });
        }

        public Task<bool> SetUnreadDocAndMsgCount(int consumerFileId, CountNotificationType notificationType, bool docCount, bool msgCount, int? unreadDocCount, int? unreadMsgCount)
        {
            throw new NotImplementedException();
        }
    }
}
