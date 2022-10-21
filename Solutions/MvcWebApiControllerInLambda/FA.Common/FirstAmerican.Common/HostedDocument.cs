using FirstAmerican.Common.Exceptions;
using System.Collections.Generic;

namespace FirstAmerican.Common
{
    public class HostedDocument
    {
        private static readonly Dictionary<int, string> HostedDocumentKey =
       new Dictionary<int, string>
       {
          {3, "Escrow_Action_Items_Buyer_AZ"},
          {4, "Escrow_Action_Items_Borrower_AZ"},
          {5, "Escrow_Action_Items_Seller_AZ"},
          {6, "Escrow_Action_Items_Buyer_FL"},
          {7, "Escrow_Action_Items_Borrower_FL"},
          {9, "Privacy_Policy"},
          {23, "Cyber_Fraud_Warning_for_Buyer"},
          {24, "Cyber_Fraud_Warning_for_Seller"},
          {91, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {92, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {93, "Escrow_Action_Items_Buyer_WA"},
          {94, "Escrow_Action_Items_Borrower_WA"},
          {95, "Escrow_Action_Items_Seller_WA"},
          {96, "Ways_to_Take_Title_AZ"},
          {97, "Escrow_Action_Items_Buyer_OR"},
          {98, "Escrow_Action_Items_Borrower_OR"},
          {99, "Escrow_Action_Items_Seller_OR"},
          {100, "OR_Ways_to_Hold_Title_OR"},
          {105, "OR_WC_Form_OR"},
          {112, "Escrow_Action_Items_Buyer_OH"},
          {113, "Escrow_Action_Items_Borrower_OH"},
          {114, "Escrow_Action_Items_Seller_OH"},
          {115, "Escrow_Action_Items_Buyer_MN"},
          {116, "Escrow_Action_Items_Borrower_MN"},
          {117, "Escrow_Action_Items_Seller_MN"},
          {118, "Ways_to_Take_Title_MN"},
          {119, "_7ReasonsOTI_MN"},
          {120, "Escrow_Action_Items_Buyer_TX"},
          {121, "Escrow_Action_Items_Borrower_TX"},
          {122, "Escrow_Action_Items_Seller_TX"},
          {129, "Ways_to_Take_Title_FL"},
          {132, "Escrow_Action_Items_Buyer_CA"},
          {133, "Escrow_Action_Items_Borrower_CA"},
          {134, "Escrow_Action_Items_Seller_CA"},
          {135, "Ways_to_Take_Title_CA"},
          {136, "Notice_of_Opportunity_to_Earn_Interest_CA"},
          {137, "First_American_Property_Casualty_Flyer"},
          {142, "Directions_to_First_American_Office_AZ"},
          {143, "Email_Security_Tips_AZ"},
          {144, "Tips_to_Avoid_Last_Minute_Delays_AZ"},
          {147, "First_American_Property_Casualty_Flyer"},
          {148, "Escrow_Action_Items_Buyer_CO"},
          {149, "Escrow_Action_Items_Borrower_CO"},
          {150, "Escrow_Action_Items_Seller_CO"},
          {151, "First_American_Property_Casualty_Flyer"},
          {152, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {153, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {154, "Escrow_Action_Items_Buyer_NV"},
          {155, "Escrow_Action_Items_Borrower_NV"},
          {156, "Escrow_Action_Items_Seller_NV"},
          {157, "Ways_to_Take_Title_NV"},
          {158, "First_American_Property_Casualty_Flyer"},
          {159, "Escrow_Action_Items_Buyer_NM"},
          {160, "Escrow_Action_Items_Borrower_NM"},
          {161, "Escrow_Action_Items_Seller_NM"},
          {162, "Ways_to_Take_Title_NM"},
          {175, "Life_of_an_Escrow_Sale_CA"},
          {176, "Life_of_an_Escrow_Refi_CA"},
          {177, "Life_of_an_Escrow_Sale_CA"},
          {178, "Email_Security_Tips"},
          {179, "Acceptable_Identification"},
          {180, "General_Information"},
          {181, "Escrow_Action_Items_Buyer_AK"},
          {182, "Escrow_Action_Items_Borrower_AK"},
          {183, "Escrow_Action_Items_Seller_AK"},
          {188, "Escrow_Action_Items_Buyer_CA_NCA"},
          {189, "First_American_Property_Casualty_Flyer"},
          {190, "Escrow_Action_Items_Borrower_CA_NCA"},
          {191, "Escrow_Action_Items_Seller_CA_NCA"},
          {192, "Escrow_Action_Items_Buyer_CA_NCA_New_Homes"},
          {193, "First_American_Property_Casualty_Flyer"},
          {194, "General_Information_CA_NCA_New_Homes"},
          {195, "Escrow_Action_Items_Buyer_MI"},
          {196, "Escrow_Action_Items_Borrower_MI"},
          {197, "Escrow_Action_Items_Seller_MI"},
          {199, "Escrow_Action_Items_Buyer_IN"},
          {200, "Escrow_Action_Items_Borrower_IN"},
          {201, "Escrow_Action_Items_Seller_IN"},
          {202, "Ways_to_Take_Title_IN"},
          {203, "Office_Locations_IN"},
          {204, "Escrow_Action_Items_Buyer_ID"},
          {205, "Escrow_Action_Items_Borrower_ID"},
          {206, "Escrow_Action_Items_Seller_ID"},
          {209, "First_American_Property_Casualty_Flyer"},
          {210, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {211, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {212, "Notice_of_Opportunity_to_Earn_Interest_CA"},
          {213, "First_American_Property_Casualty_Flyer"},
          {214, "Cyber_Fraud_Warning_for_Borrower"},
          {217, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {218, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {219, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {220, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {223, "Escrow_Action_Items___Buyer__NM___Dona_Ana_" },//Escrow Action Items - Buyer (NM - Dona Ana)
          {224, "Escrow_Action_Items___Borrower__SCA___Regency_" },//Escrow Action Items - Borrower (SCA - Regency).docx
          {225, "Escrow_Action_Items___Buyer__SCA___Regency_" },//Escrow Action Items - Buyer (SCA - Regency).docx
          {226, "Escrow_Action_Items___Buyer__SCA___Heritage_" },//Escrow Action Items - Buyer (SCA - Heritage).docx
          {227, "Escrow_Action_Items___Borrower__SCA___Heritage_" },//Escrow Action Items - Borrower (SCA - Heritage).docx
          {228, "Privacy_Policy___Heritage" },//Privacy Policy - Heritage.doc
          {229, "Escrow_Action_Items___Seller__SCA___Regency_" },//Escrow Action Items - Seller (SCA - Regency).docx
          {230, "Escrow_Action_Items___Seller__NM___Dona_Ana_" },//Escrow Action Items - Seller (NM - Dona Ana).docx
          {231, "Escrow_Action_Items___Borrower__NM___Dona_Ana_" },//Escrow Action Items - Borrower (NM - Dona Ana).docx
          {232, "Escrow_Action_Items___Seller__SCA___Heritage_" },//Escrow Action Items - Seller (SCA - Heritage).docx
          {233, "Life_of_a_Builder_Escrow_NV"},
          {234, "Directions_to_First_American_Office_NV"},
          {235, "Borrower_s_Payoff_Authorization___Heritage" },//Borrower's Payoff Authorization - Heritage.pdf
          {236, "Borrower_s_Payoff_Authorization___Regency" },//Borrower's Payoff Authorization - Regency.pdf
          {237, "Borrower_s_Payoff_Authorization___Dona_Ana" }, //Borrower's Payoff Authorization - Dona Ana.pdf
          {238, "Understanding_Title_Insurance_CO" },
          {239, "Closing_Your_New_Home_CO" },
          {240, "Escrow_Action_Items_Buyer_OK" },
          {241, "Ways_to_Take_Title_OK" },
          {242, "What_is_Title_Insurance_Buyer_OK" },
          {243, "FIRPTA_Notice_for_Buyer_and_Seller" },
          {244, "Escrow_Action_Items_Borrower_OK" },
          {245, "Escrow_Action_Items_Seller_OK" },
          {246, "FIRPTA_Notice_for_Buyer_and_Seller" },
          {247, "Cyber_Fraud_Warning_for_Borrower" },
          {248, "Email_Security_Tips"},
          {249, "Email_Security_Tips"},
          {252, "Escrow_Action_Items_Buyer_KS"},
          {253, "Ways_to_Take_Title_KS"},
          {254, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {255, "Escrow_Action_Items_Borrower_KS"},
          {256, "Escrow_Action_Items_Seller_KS"},
          {257, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {258, "Escrow_Action_Items_Buyer_MO"},
          {259, "Ways_to_Take_Title_MO"},
          {260, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {261, "Escrow_Action_Items_Borrower_MO"},
          {262, "Escrow_Action_Items_Seller_MO"},
          {263, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {264, "Escrow_Action_Items_Buyer_WY"},
          {265, "Escrow_Action_Items_Borrower_WY"},
          {266, "Escrow_Action_Items_Seller_WY"},
          {267, "Escrow_Action_Items_Buyer_UT"},
          {268, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {269, "Escrow_Action_Items_Borrower_UT"},
          {270, "Cyber_Fraud_Warning_for_Borrower"},
          {271, "Escrow_Action_Items_Seller_UT"},
          {272, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {290, "Ways_to_Take_Title_WI"},
          {291, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {292, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {294, "Ways_to_Take_Title_IL"},
          {295, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {296, "Wire_Instructions_IL"},
          {297, "Office_Locations_IL"},
          {298, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {299, "Cyber_Fraud_Warning_for_Borrower"},
          {301, "Ways_to_Take_Title_NJ"},
          {302, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {303, "What_to_Expect_at_Closing_NJ"},
          {304, "FIRPTA_Notice_for_Buyer_and_Seller"},
          {305, "What_to_Expect_at_Closing_NJ"},
          {307, "Escrow_Action_Items_Buyer_MD"},
          {309, "Escrow_Action_Items_Buyer_VA"},
          {317, "Cyber_Fraud_Warning_to_Buyers__Regency_"},
          {318, "Cyber_Fraud_Warning_to_Buyers__Heritage_"},
          {319, "Cyber_Fraud_Warning_to_Sellers__Regency_"},
          {320, "Cyber_Fraud_Warning_to_Sellers__Heritage_"},
          {321, "Life_of_an_Escrow___Refi__Heritage_"},
          {322, "Life_of_an_Escrow___Refi__Regency_"},
          {323, "Life_of_an_Escrow___Sale__Heritage_"},
          {324, "Life_of_an_Escrow___Sale__Regency_"},
          {325, "Life_of_an_Escrow___Sale__Heritage_"},
          {326, "Life_of_an_Escrow___Sale__Regency_"},
          {327, "Ways_to_Take_Title__Heritage_"},
          {328, "Ways_to_Take_Title__Regency_"},
          {336, "Borrower_s_Payoff_Authorization___TitleVest"},
          {337, "Borrower_s_Payoff_Authorization___Republic_Title" },//Borrower's Payoff Authorization - Republic Title.pdf
          {338, "Borrower_s_Payoff_Authorization___Reunion_Title" },//Borrower's Payoff Authorization - Reunion Title.pdf
       };

        public static string GetNameForId(int documentMappingId)
        {
            if (IsIdHosted(documentMappingId))
            {
                return HostedDocumentKey[documentMappingId];
            }
            else
            {
                throw new DocumentTypeIsNotHosted("The document ID is not hosted");
            }
        }

        public static bool IsIdHosted(int documentMappingId) => HostedDocumentKey.ContainsKey(documentMappingId);
    }
}