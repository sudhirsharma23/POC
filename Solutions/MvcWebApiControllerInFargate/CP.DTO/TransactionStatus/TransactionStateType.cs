using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.DTO.TransactionStatus
{
    public enum TransactionStateType
    {
        NotStarted,
        Current,
        Complete,
        Error
    }

    public enum LandingPageMessageType
    {
        FileOpened=1,
        UnReadMessage=2,
        FileInProcess=3,
        HusbandWifeDataCollectionStarted=4,
        IndividualDataCollectionStarted=5,
        FileClosed=6,
        LiveSignPending=7,
        NewlyRegistered=8,
        NewlyRegisteredSpouseDataCollectionStarted=9,
        NewUserDataCollectionStarted = 10,
        SpouseRegistrationPending = 11,
        MultiFileNewlyRegistered=12,
        MultiFileNewlyRegisteredSpouseDataCollectionStarted=13,
        MultiFileNewUserDataCollectionStarted=14,
        NewUserUnReadMessage = 15,
        LiveSignPendingDocuSignNotRequired = 16,
        MultiEsignRequired=17,
        UnReadDoc=18,
        SecondaryEsignCompleted=19,
        OneSpouseCompletedSecondaryESigning=20,
        BuyerRegistrationNotComplete=21,
        SellerRegistrationNotComplete =22,
        BuyerQANotCompleted=23,
        SellerQANotCompleted=24,
        AgentOrTCDataCollectionStarted = 25,
        AgentFileOpened=26,
        AchOption = 27

    }

}
