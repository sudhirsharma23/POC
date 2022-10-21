using CP.Core.User;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CP.DTO;
using System.Collections.Generic;
using CP.Core.User.Impl;

namespace FilesAPI
{
    [Route("api/Files")]
    public class FilesController : BaseApiController
    {
        private readonly IUserManager userManager;

        public FilesController()
        {
            userManager = new UserManager();
        }

        [HttpGet]
        public async Task<List<ConsumerFileDto>> GetConsumerDetails()
        {

            if (!string.IsNullOrEmpty(Identity))
            {
                List<ConsumerFileDto> consumerDetails = await userManager.GetConsumerDetailsByIdentity(Identity);
                return consumerDetails;
            }

            return null;
        }

        [HttpGet("counts/{consumerFileId}")]
        public async Task<NotificationCountDetails> GetCounts(int consumerFileId)
        {
            try
            {
                NotificationCountDetails resp = await userManager.GetCounts(consumerFileId, Identity);

                return resp;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
                throw;
            }
        }

        [HttpGet("NotificationCount")]
        public async Task<NotificationCount> GetUnreadNotificationCount()
        {
            if (!string.IsNullOrEmpty(Identity))
            {
                NotificationCount lstCount = await userManager.GetUnreadNotificationCount(Identity);
                return lstCount;
            }

            return new NotificationCount();
        }
    }
}