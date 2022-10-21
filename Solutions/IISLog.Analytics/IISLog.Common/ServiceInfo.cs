using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLog.Common
{
    public class ServiceInfo
    {
        public string dbPath;
        public string ltOneSecondCountPct;
        public int ltOneSecondCount;
        public int err500Count;
        public int count;
        public string path;
        public string maxRes = string.Empty;
        public string maxReq = string.Empty;

        public ServiceInfo(int count, string path)
        {
            this.count = count;
            this.path = path;

        }

        public string GetitOneSecondCountPct()
        {
            if (ltOneSecondCount == count)
            {
                return "100%";
            }

            return (Convert.ToDouble(ltOneSecondCount) / count).ToString("0.0%");

        }

        public string GetServiceName()
        {
            if (path.IndexOf("FileService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "File Service";
            }
            else if (path.IndexOf("AdminService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Admin Service";
            }
            else if (path.IndexOf("DocumentPreparation", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "DocPreparation Service";
            }
            else if (path.IndexOf("GABService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "GAB Service";
            }
            else if (path.IndexOf("BizTalkService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "BizTalk Service";
            }
            else if (path.IndexOf("EscrowService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Escrow Service";
            }
            else if (path.IndexOf("EventService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Event Service";
            }
            else if (path.IndexOf("FASTOrderEntryWebService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "ClientWeb Service";
            }
            else if (path.IndexOf("FastDocumentService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Document Service";
            }
            else if (path.IndexOf("RecordedDocWS", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "RecordedDoc Service";
            }
            else if (path.IndexOf("WorkflowService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Workflow Service";
            }
            else if ((path.IndexOf("FASTSERVICEINTERFACE", StringComparison.OrdinalIgnoreCase) > 0) || (path.IndexOf("fastwebservice", StringComparison.OrdinalIgnoreCase) > 0))
            {
                return "CustomerView Service";
            }
            else if (path.IndexOf("DateDownWs", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "DateDown Service";
            }
            else if (path.IndexOf("ClosingDisclosure", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "CD Service";
            }
            else if (path.IndexOf("FASTTrust32WebService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "PaidCheckStatus Service";
            }
            else if (path.IndexOf("FastUtilityService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Utility Service";
            }
            else if (path.IndexOf("docrequestws", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "DocRequest Service";
            }
            else if (path.IndexOf("CheckInfoWS", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "CheckInfo Service";
            }
            else if (path.IndexOf("UpdateDataHub", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "UpdateDataHub Service";
            }
            else if (path.IndexOf("SecurityService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "Security Service";
            }
            else if (path.IndexOf("RTMEventLogDetailWS", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "RTMEventLog Service";
            }
            else if (path.IndexOf("AttachDocumentWS", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "AttachDocument Service";
            }
            else if (path.IndexOf("FastSearchResponseHandlerWS", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "FASTSearchResponse Service";
            }
            else if (path.IndexOf("FAFInternalBistroWS", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "FAFInternalBistral Service";
            }
            else if (path.IndexOf("FASTMDMService", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "MDM Service";
            }
            else if (path.IndexOf("TempIntDocs", StringComparison.OrdinalIgnoreCase) > 0)
            {
                return "TempIntDocs Service";
            }
            return path;
        }
    }
}
