using CP.DTO;
using CP.Core.User;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CP.Core.User.Impl
{
    public class UserManager : IUserManager
    {
        private readonly IConsumerRepository consumerRepository;

        public UserManager()
        {
            this.consumerRepository = new ConsumerRepository();
        }

        public UserManager(IConsumerRepository consumerRepository){
            this.consumerRepository = consumerRepository;
        }

        private async Task<int> GetUnreadMessageCount(int consumerFileId, string identity)
        {
            //var messageResponseDto = await _messageManager.GetMessagesCount(identity, 1, consumerFileId.ToString());
            //return messageResponseDto.TotalUnreadMessages;
            return await Task.Run(() => { return 5; });
        }

        private async Task<int> GetUnreadDocCount(int consumerFileId, string identity)
        {
            //var documents = await _documentManager.GetFASTDocuments(new DocumentRequestDto { Identity = identity, ConsumerFileId = consumerFileId.ToString() });

            //int unreadDcos = documents != null ? documents.ToList().Count(msg => msg.IsRead == false) : 0;
            //return unreadDcos;

            return await Task.Run(() => { return 3; });
        }

        private async Task<int> GetSecondaryEsignCount(int consumerFileId, string identity)
        {
            return await Task.Run(() => { return 1; });
        }

        public async Task<NotificationCount> GetUnreadNotificationCount(string identity)
        {
            NotificationCount notificationCount = new NotificationCount
            {
                lstCount = new List<NotificationCountDetails>()
            };

            List<ConsumerFileDto> consumerinfos = await GetConsumerDetailsByIdentity(identity);

            var consumerFileIds = from fileIds in consumerinfos select fileIds.ConsumerFileId;

            foreach (int fileID in consumerFileIds)
            {
                var notificationcountDetails = new NotificationCountDetails
                {
                    consumerFileId = fileID,
                    UnreadMsgCount = await GetUnreadMessageCount(fileID, identity),//unreadmsgcount,
                    UnreadDocCount = await GetUnreadDocCount(fileID, identity)//unreaddoccount
                };
                notificationCount.lstCount.Add(notificationcountDetails);
            }

            return notificationCount;
        }

        public async Task<NotificationCountDetails> GetCounts(int consumerFileId, string identity)
        {
            UnreadDocAndMsgCount msgDocCount = await this.consumerRepository.GetUnreadDocAndMsgCount(consumerFileId);
            if (msgDocCount.Success)
            {
                int esignCount = await this.GetSecondaryEsignCount(consumerFileId, identity);
                NotificationCountDetails newCount = new NotificationCountDetails
                {
                    consumerFileId = consumerFileId,
                    SecEsignCount = esignCount,
                    UnreadDocCount = msgDocCount.UnreadDocCount.Value,
                    UnreadMsgCount = msgDocCount.UnreadMsgCount.Value,
                };
                return newCount;
            }
            NotificationCountDetails notificationCount = new NotificationCountDetails
            {
                consumerFileId = consumerFileId,
                UnreadDocCount = await GetUnreadDocCount(consumerFileId, identity),
                UnreadMsgCount = await GetUnreadMessageCount(consumerFileId, identity),
                SecEsignCount = await GetSecondaryEsignCount(consumerFileId, identity)
            };
            _ = await consumerRepository.SetUnreadDocAndMsgCount(consumerFileId, CountNotificationType.LoginNotification, true, true, notificationCount.UnreadDocCount, notificationCount.UnreadMsgCount);
            return notificationCount;
        }

        public async Task<List<ConsumerFileDto>> GetConsumerDetailsByIdentity(string identity)
        {
            var consumerInfos = await consumerRepository.GetConsumerFilesByIdentity(identity);
            var consumerFiles = new List<ConsumerFileDto>();
            var consumerInfosbyIdentity = consumerInfos?.Where(x => string.Equals(Convert.ToString(x.IdentityId), identity, StringComparison.CurrentCultureIgnoreCase));

            //RE Agent Related changes
            foreach (var consumer in consumerInfosbyIdentity)
            {
                if (consumer.ConsumerType.IsReAgentByConsumerType())
                {
                    if (consumer.ConsumerFileStatus != ConsumerFileStatus.OptOut)
                    {
                        var associatedConsumers = new List<ConsumerFileDto>();
                        var agentBuyerSellerFile = new List<ConsumerFileDto>();
                        if (consumer.ConsumerType.IsSellerTypeREAgent())
                        {
                            associatedConsumers = consumerInfos.Where(x => x.ConsumerFileId != consumer.ConsumerFileId && x.IdentityId != consumer.IdentityId && x.FastFileId == consumer.FastFileId && x.ConsumerFileStatus != ConsumerFileStatus.Deactivated && !x.ConsumerType.IsReAgentByConsumerType() && x.ConsumerType == ConsumerType.Seller).ToList();
                            agentBuyerSellerFile = consumerInfos.Where(x => x.ConsumerFileId != consumer.ConsumerFileId && x.IdentityId == consumer.IdentityId && x.FastFileId == consumer.FastFileId && x.ConsumerFileStatus != ConsumerFileStatus.Deactivated && !x.ConsumerType.IsReAgentByConsumerType() && x.ConsumerType == ConsumerType.Seller).ToList();
                        }
                        else
                        {
                            associatedConsumers = consumerInfos.Where(x => x.ConsumerFileId != consumer.ConsumerFileId && x.IdentityId != consumer.IdentityId && x.FastFileId == consumer.FastFileId && x.ConsumerFileStatus != ConsumerFileStatus.Deactivated && !x.ConsumerType.IsReAgentByConsumerType() && (x.ConsumerType == ConsumerType.Buyer)).ToList();
                            agentBuyerSellerFile = consumerInfos.Where(x => x.ConsumerFileId != consumer.ConsumerFileId && x.IdentityId == consumer.IdentityId && x.FastFileId == consumer.FastFileId && x.ConsumerFileStatus != ConsumerFileStatus.Deactivated && !x.ConsumerType.IsReAgentByConsumerType() && x.ConsumerType == ConsumerType.Buyer).ToList();
                        }
                        var consumerType = ConvertConsumerType((int)consumer.ConsumerType);
                        var inEligibleConsumers = await consumerRepository.GetCurrentInEligibleConsumers(consumer.FastFileId, consumerType.Value);
                        if (associatedConsumers != null && associatedConsumers.Any())
                        {
                            associatedConsumers.AddRange(inEligibleConsumers);
                            //Show Only First Buyer And Seller Per File Associated With REATC
                            associatedConsumers = associatedConsumers.GroupBy(m => m.ConsumerType).Select(m => m.OrderBy(x => x.SeqNum).First()).ToList();
                            var assocociated = associatedConsumers.FirstOrDefault();
                            UpdateName(ref assocociated);
                            consumerFiles.AddRange(associatedConsumers.Select(m => MapConsumer(consumer, m)));
                        }
                        else
                        {
                            if (inEligibleConsumers != null && inEligibleConsumers.Any())
                            {
                                var firstInEligibleConsumer = inEligibleConsumers.First(m => m.SeqNum == 1);
                                UpdateName(ref firstInEligibleConsumer);
                                MapToInEligibleConsumer(consumer, ref firstInEligibleConsumer);
                                consumerFiles.Add(firstInEligibleConsumer);
                            }
                            else
                            {
                                consumer.IsReAgent = true;
                                consumer.LoggedInUserConsumerFileId = consumer.ConsumerFileId;
                                consumer.LoggedInUserFirstName = consumer.FirstName;
                                consumer.ConsumerFileId = consumer.ConsumerFileId;
                                if (agentBuyerSellerFile.Any())
                                {
                                    var consumerFile = consumer;
                                    UpdateName(ref consumerFile);
                                    consumerFiles.Add(consumerFile);
                                }
                                else
                                {
                                    consumer.Name = string.Empty;
                                    consumerFiles.Add(consumer);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (consumerInfosbyIdentity.Any(x => x.IdentityId == consumer.IdentityId && x.ConsumerFileId != consumer.ConsumerFileId) && consumer.ConsumerFileStatus == ConsumerFileStatus.OptOut) continue;
                    consumer.LoggedInUserFirstName = consumer.FirstName;
                    var consumerFile = consumer;
                    UpdateName(ref consumerFile);
                    consumerFiles.Add(consumerFile);
                }
            }
            return consumerFiles;
        }

        private void UpdateName(ref ConsumerFileDto consumer)
        {
            consumer.Name = consumer.ShortName ?? consumer.LastName ?? consumer.FirstName;
        }

        private void MapToInEligibleConsumer(ConsumerFileDto consumer, ref ConsumerFileDto firstInEligibleConsumer)
        {
            firstInEligibleConsumer.LoggedInUserConsumerFileId = consumer.ConsumerFileId;
            firstInEligibleConsumer.IsReAgent = true;
            firstInEligibleConsumer.LastFileAccessDate = consumer.LastFileAccessDate;
            firstInEligibleConsumer.AccountCreatedDate = consumer.AccountCreatedDate;
            firstInEligibleConsumer.LoggedInUserFirstName = consumer.FirstName;
            firstInEligibleConsumer.ConsumerFileStatus = consumer.ConsumerFileStatus;
            firstInEligibleConsumer.LandedToDashBoard = consumer.LandedToDashBoard;
        }

        private ConsumerType? ConvertConsumerType(int? consumer)
        {
            if (consumer == (int)ConsumerType.BuyerAgent || consumer == (int)ConsumerType.BuyerTC)
            {
                return ConsumerType.Buyer;
            }
            else if (consumer == (int)ConsumerType.SellerAgent || consumer == (int)ConsumerType.SellerTC)
            {
                return ConsumerType.Seller;
            }
            else
                return (ConsumerType)consumer;
        }

        private ConsumerFileDto MapConsumer(ConsumerFileDto consumer, ConsumerFileDto m)
        {
            return new ConsumerFileDto
            {
                AccountCreatedDate = consumer.AccountCreatedDate,
                AdditionalContactId = m.AdditionalContactId,
                AdminFileStatus = m.AdminFileStatus,
                AuthSignatureID = m.AuthSignatureID,
                BUID = m.BUID,
                BuisnessPhoneExtension = m.BuisnessPhoneExtension,
                BusinessPrograms = m.BusinessPrograms,
                BusinessSegment = m.BusinessSegment,
                BusOrgId = m.BusOrgId,
                BuyerSellerType = m.BuyerSellerType,
                ConsumerFileId = m.ConsumerFileId,
                ConsumerFileStatus = m.ConsumerFileStatus,
                ConsumerType = m.ConsumerType,
                ConsumerTypeId = m.ConsumerTypeId,
                ContactId = m.ContactId,
                CreatedOn = m.CreatedOn,
                DateOfRegistration = m.DateOfRegistration,
                DocumentName = m.DocumentName,
                Email = m.Email,
                EnvelopeToBeESigned = m.EnvelopeToBeESigned,
                EscrowOfficeName = m.EscrowOfficeName,
                EstSettlementDate = m.EstSettlementDate,
                EulaDate = m.EulaDate,
                FASTBusinessSegmentID = m.FASTBusinessSegmentID,
                FASTBuyerSellerTypeId = m.FASTBuyerSellerTypeId,
                FastFileId = m.FastFileId,
                FASTFileNumber = m.FASTFileNumber,
                FastFileStatus = m.FastFileStatus,
                FASTRegion = m.FASTRegion,
                FaxNumber = m.FaxNumber,
                FileBusinessPartyID = m.FileBusinessPartyID,
                FileClosedOn = m.FileClosedOn,
                FileCreatedDate = m.FileCreatedDate,
                FileOpenDate = m.FileOpenDate,
                FileType = m.FileType,
                FirstName = m.FirstName,
                HistoryId = m.HistoryId,
                HomePhone = m.HomePhone,
                IdentityId = m.IdentityId,
                IsAdHocContact = m.IsAdHocContact,
                IsAutoRegistrationEligible = m.IsAutoRegistrationEligible,
                IsFileExpired = m.IsFileExpired,
                IsPrimary = m.IsPrimary,
                IsReAgent = true,
                LastFileAccessDate = consumer.LastFileAccessDate,
                LastName = m.LastName,
                LastProfileUpdateDate = consumer.LastProfileUpdateDate,
                LoggedInUserConsumerFileId = consumer.ConsumerFileId,
                MiddleName = m.MiddleName,
                MobilePhone = m.MobilePhone,
                NotificationPreference = m.NotificationPreference,
                PrincipalId = m.PrincipalId,
                PropertyAddressDescription = m.PropertyAddressDescription,
                PropertyCounty = m.PropertyCounty,
                PropertyAddressLine1 = m.PropertyAddressLine1,
                PropertyCity = m.PropertyCity,
                PropertyState = m.PropertyState,
                QACompleted = m.QACompleted,
                QADisabled = m.QADisabled,
                RegionID = m.RegionID,
                SeqNum = m.SeqNum,
                ShortName = m.ShortName,
                ShowSecondaryESign = m.ShowSecondaryESign,
                State = m.State,
                TransactionType = m.TransactionType,
                UnreadDocCount = m.UnreadDocCount,
                UnreadMsgCount = m.UnreadMsgCount,
                UserNameSuffix = m.UserNameSuffix,
                WorkPhone = m.WorkPhone,
                LoggedInUserFirstName = consumer.FirstName,
                LandedToDashBoard = m.LandedToDashBoard,
                CssClass = m.CssClass,
                Name = m.Name
            };
        }

    }
}