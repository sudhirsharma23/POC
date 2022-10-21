using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISLog.Common
{
    public class ServiceStats
    {
        public static ServiceInfo FileService = new ServiceInfo(0, "File Service");
        public static ServiceInfo AdminService = new ServiceInfo(0, "Admin Service");
        public static ServiceInfo WorkflowService = new ServiceInfo(0, "Workflow Service");
        public static ServiceInfo DocumentService = new ServiceInfo(0, "Document Service");
        public static ServiceInfo SecurityService = new ServiceInfo(0, "Security Service");
        public static ServiceInfo EventService = new ServiceInfo(0, "Event Service");
        public static ServiceInfo CDService = new ServiceInfo(0, "CD Service");
        public static ServiceInfo EscrowService = new ServiceInfo(0, "Escrow Service");
        public static ServiceInfo GABService = new ServiceInfo(0, "GAB Service");
        public static ServiceInfo BizTalkService = new ServiceInfo(0, "BizTalk Service");
        public static ServiceInfo ClientWebService = new ServiceInfo(0, "ClientWeb Service");
        public static ServiceInfo PaidCheckStatusService = new ServiceInfo(0, "PaidCheckStatus Service");
        public static ServiceInfo CustomerViewService = new ServiceInfo(0, "CustomerView Service");
        public static ServiceInfo DocRequestService = new ServiceInfo(0, "DocRequest Service");
        public static ServiceInfo DocPreparationService = new ServiceInfo(0, "DocPreparation Service");
        public static ServiceInfo DataHubService = new ServiceInfo(0, "UpdateDataHub Service");
        public static ServiceInfo CheckInfoService = new ServiceInfo(0, "CheckInfo Service");
        public static ServiceInfo MDMService = new ServiceInfo(0, "MDM Service");
        public static ServiceInfo DateDownService = new ServiceInfo(0, "DateDown Service");
        public static ServiceInfo RecordedDocService = new ServiceInfo(0, "RecordedDoc Service");
        public static ServiceInfo FAFInternalBistroService = new ServiceInfo(0, "FAFInternalBistro Service");
        public static ServiceInfo RTMEventLogService = new ServiceInfo(0, "RTMEventLog Service");
        public static ServiceInfo FASTSearchResponseService = new ServiceInfo(0, "FASTSearchResponse Service");
        public static ServiceInfo AttachDocumentService = new ServiceInfo(0, "AttachDocument Service");
        public static ServiceInfo UtilityService = new ServiceInfo(0, "Utility Service");
        public static ServiceInfo TempIntDocsService = new ServiceInfo(0, "TempIntDocs Service");

        public static List<ServiceInfo> ServiceInfoList = new List<ServiceInfo>();
        public static List<ServiceInfo> OrderedServiceInfoList = new List<ServiceInfo>();

        public static List<ServiceInfo> IISServiceInfoList = new List<ServiceInfo>();

        public static List<ServiceInfo> PopulateIISServiceInfo(List<ServiceInfo> newDataList, List<ServiceInfo> errorDataList)
        {
            var SplitDocService = new ServiceInfo(0, "Split Doc");
            var UploadDocument = new ServiceInfo(0, "Upload Document");
            var ImageDownLoad = new ServiceInfo(0, "Image Download");
            var WorkQueues = new ServiceInfo(0, "Work Queues");
            var FileSearch = new ServiceInfo(0, "File Search");
            var DocPrep = new ServiceInfo(0, "Doc Prep");
            var FileWorkFlow = new ServiceInfo(0, "File Workflow");
            var PrintDelivery = new ServiceInfo(0, "Print Delivery");
            var DocumentPreparation = new ServiceInfo(0, "Document Preparation");
            var FeeEntry = new ServiceInfo(0, "FeeEntry");
            var BusOrgSearch = new ServiceInfo(0, "BusOrgSearch");

            IISServiceInfoList.Add(FeeEntry);
            IISServiceInfoList.Add(DocumentPreparation);
            IISServiceInfoList.Add(SplitDocService);
            IISServiceInfoList.Add(UploadDocument);
            IISServiceInfoList.Add(ImageDownLoad);
            IISServiceInfoList.Add(WorkQueues);
            IISServiceInfoList.Add(FileSearch);
            IISServiceInfoList.Add(DocPrep);
            IISServiceInfoList.Add(FileWorkFlow);
            IISServiceInfoList.Add(PrintDelivery);
            IISServiceInfoList.Add(BusOrgSearch);
            

            foreach (ServiceInfo info in newDataList)
            {
                if (info.path.IndexOf("SplitDoc", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    SplitDocService.count += info.count;
                    
                }
                else if (info.path.IndexOf("UploadDocument.aspx", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    UploadDocument.count += info.count;
                    
                }
                else if (info.path.IndexOf("ImageDownloadService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    ImageDownLoad.count += info.count;

                }
                else if (info.path.IndexOf("WorkQueues", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    WorkQueues.count += info.count;

                }
                else if (info.path.IndexOf("FileSearch.aspx", StringComparison.OrdinalIgnoreCase) > 0)
                { 
                    FileSearch.count += info.count;

                }
                else if (info.path.IndexOf("DocPrep", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocPrep.count += info.count;

                }
                else if (info.path.IndexOf("WorkFlowGUI/FileWorkFlow.aspx", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FileWorkFlow.count += info.count;

                }
                else if (info.path.IndexOf("PrintDeliveryGUI/PrintSysDocument.aspx", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    PrintDelivery.count += info.count;

                }
                else if (info.path.IndexOf("DocumentPreparation", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocumentPreparation.count += info.count;

                }
                else if (info.path.IndexOf("FeeEntry", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FeeEntry.count += info.count;

                }
                else if (info.path.IndexOf("BusOrgSearch", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    BusOrgSearch.count += info.count;

                }
            }
            return IISServiceInfoList;
        }

        public static List<ServiceInfo> PopulateServiceInfo(List<ServiceInfo> newDataList, List<ServiceInfo> errorDataList)
        {
            FileService = new ServiceInfo(0, "File Service");
            AdminService = new ServiceInfo(0, "Admin Service");
            WorkflowService = new ServiceInfo(0, "Workflow Service");
            DocumentService = new ServiceInfo(0, "Document Service");
            SecurityService = new ServiceInfo(0, "Security Service");
            EventService = new ServiceInfo(0, "Event Service");
            CDService = new ServiceInfo(0, "CD Service");
            EscrowService = new ServiceInfo(0, "Escrow Service");
            GABService = new ServiceInfo(0, "GAB Service");
            BizTalkService = new ServiceInfo(0, "BizTalk Service");
            ClientWebService = new ServiceInfo(0, "ClientWeb Service");
            PaidCheckStatusService = new ServiceInfo(0, "PaidCheckStatus Service");
            CustomerViewService = new ServiceInfo(0, "CustomerView Service");
            DocRequestService = new ServiceInfo(0, "DocRequest Service");
            DocPreparationService = new ServiceInfo(0, "DocPreparation Service");
            DataHubService = new ServiceInfo(0, "UpdateDataHub Service");
            CheckInfoService = new ServiceInfo(0, "CheckInfo Service");
            MDMService = new ServiceInfo(0, "MDM Service");
            DateDownService = new ServiceInfo(0, "DateDown Service");
            RecordedDocService = new ServiceInfo(0, "RecordedDoc Service");
            FAFInternalBistroService = new ServiceInfo(0, "FAFInternalBistro Service");
            RTMEventLogService = new ServiceInfo(0, "RTMEventLog Service");
            FASTSearchResponseService = new ServiceInfo(0, "FASTSearchResponse Service");
            AttachDocumentService = new ServiceInfo(0, "AttachDocument Service");
            UtilityService = new ServiceInfo(0, "Utility Service");
            TempIntDocsService = new ServiceInfo(0, "TempIntDocs Service");

            ServiceInfoList.Add(FileService);
            ServiceInfoList.Add(AdminService);
            ServiceInfoList.Add(WorkflowService);
            ServiceInfoList.Add(DocumentService);
            ServiceInfoList.Add(SecurityService);
            ServiceInfoList.Add(EventService);
            ServiceInfoList.Add(CDService);
            ServiceInfoList.Add(EscrowService);
            ServiceInfoList.Add(GABService);
            ServiceInfoList.Add(BizTalkService);
            ServiceInfoList.Add(ClientWebService);
            ServiceInfoList.Add(PaidCheckStatusService);
            ServiceInfoList.Add(CustomerViewService);
            ServiceInfoList.Add(DocRequestService);
            ServiceInfoList.Add(DocPreparationService);
            ServiceInfoList.Add(DataHubService);
            ServiceInfoList.Add(CheckInfoService);
            ServiceInfoList.Add(MDMService);
            ServiceInfoList.Add(DateDownService);
            ServiceInfoList.Add(RecordedDocService);
            ServiceInfoList.Add(FAFInternalBistroService);
            ServiceInfoList.Add(RTMEventLogService);
            ServiceInfoList.Add(FASTSearchResponseService);
            ServiceInfoList.Add(AttachDocumentService);
            ServiceInfoList.Add(UtilityService);
            ServiceInfoList.Add(TempIntDocsService);

            foreach (ServiceInfo info in newDataList)
            {
                if (info.path.IndexOf("FileService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FileService.count += info.count;
                    FileService.dbPath = "FileService";
                }
                else if (info.path.IndexOf("AdminService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    AdminService.count += info.count;
                    AdminService.dbPath = "AdminService";
                }
                else if (info.path.IndexOf("DocumentPreparation", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocPreparationService.count += info.count;
                    DocPreparationService.dbPath = "DocumentPreparation";
                }
                else if (info.path.IndexOf("GABService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    GABService.count += info.count;
                    GABService.dbPath = "GABService";
                }
                else if (info.path.IndexOf("BizTalkService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    BizTalkService.count += info.count;
                    BizTalkService.dbPath = "BizTalkService";
                }
                else if (info.path.IndexOf("EscrowService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    EscrowService.count += info.count;
                    EscrowService.dbPath = "EscrowService";
                }
                else if (info.path.IndexOf("EventService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    EventService.count += info.count;
                    EventService.dbPath = "EventService";
                }
                else if (info.path.IndexOf("FASTOrderEntryWebService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    ClientWebService.count += info.count;
                    ClientWebService.dbPath = "FASTOrderEntryWebService";
                }
                else if (info.path.IndexOf("FastDocumentService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocumentService.count += info.count;
                    DocumentService.dbPath = "FastDocumentService";
                }
                else if (info.path.IndexOf("RecordedDocWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    RecordedDocService.count += info.count;
                    RecordedDocService.dbPath = "RecordedDocWS";
                }
                else if (info.path.IndexOf("WorkflowService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    WorkflowService.count += info.count;
                    WorkflowService.dbPath = "WorkflowService";
                }
                else if ((info.path.IndexOf("FASTSERVICEINTERFACE", StringComparison.OrdinalIgnoreCase) > 0) || (info.path.IndexOf("fastwebservice", StringComparison.OrdinalIgnoreCase) > 0))
                {
                    CustomerViewService.count += info.count;
                    CustomerViewService.dbPath = "FASTSERVICEINTERFACE";
                }
                else if (info.path.IndexOf("DateDownWs", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DateDownService.count += info.count;
                    DateDownService.dbPath = "DateDownWs";
                }
                else if (info.path.IndexOf("ClosingDisclosure", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    CDService.count += info.count;
                    CDService.dbPath = "ClosingDisclosure";
                }
                else if (info.path.IndexOf("FASTTrust32WebService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    PaidCheckStatusService.count += info.count;
                    PaidCheckStatusService.dbPath = "FASTTrust32WebService";
                }
                else if (info.path.IndexOf("FastUtilityService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    UtilityService.count += info.count;
                    UtilityService.dbPath = "FastUtilityService";
                }
                else if (info.path.IndexOf("docrequestws", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocRequestService.count += info.count;
                    DocRequestService.dbPath = "docrequestws";
                }
                else if (info.path.IndexOf("CheckInfoWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    CheckInfoService.count += info.count;
                    CheckInfoService.dbPath = "CheckInfoWS";
                }
                else if (info.path.IndexOf("UpdateDataHub", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DataHubService.count += info.count;
                    DataHubService.dbPath = "UpdateDataHub";
                }
                else if (info.path.IndexOf("SecurityService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    SecurityService.count += info.count;
                    SecurityService.dbPath = "SecurityService";
                }
                else if (info.path.IndexOf("RTMEventLogDetailWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    RTMEventLogService.count += info.count;
                    RTMEventLogService.dbPath = "RTMEventLogDetailWS";
                }
                else if (info.path.IndexOf("AttachDocumentWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    AttachDocumentService.count += info.count;
                    AttachDocumentService.dbPath = "AttachDocumentWS";
                }
                else if (info.path.IndexOf("FastSearchResponseHandlerWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FASTSearchResponseService.count += info.count;
                    FASTSearchResponseService.dbPath = "FastSearchResponseHandlerWS";
                }
                else if (info.path.IndexOf("FAFInternalBistroWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FAFInternalBistroService.count += info.count;
                    FAFInternalBistroService.dbPath = "FAFInternalBistroWS";
                }
                else if (info.path.IndexOf("FASTMDMService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    MDMService.count += info.count;
                    MDMService.dbPath = "FASTMDMService";
                }
                else if (info.path.IndexOf("TempIntDocs", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    TempIntDocsService.count += info.count;
                    TempIntDocsService.dbPath = "TempIntDocs";
                }

            }

            foreach (ServiceInfo info in errorDataList)
            {
                if (info.path.IndexOf("FileService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FileService.err500Count += info.count;
                }
                else if (info.path.IndexOf("AdminService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    AdminService.err500Count += info.count;
                }
                else if (info.path.IndexOf("DocumentPreparation", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocPreparationService.err500Count += info.count;
                }
                else if (info.path.IndexOf("GABService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    GABService.err500Count += info.count;
                }
                else if (info.path.IndexOf("BizTalkService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    BizTalkService.err500Count += info.count;
                }
                else if (info.path.IndexOf("EscrowService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    EscrowService.err500Count += info.count;
                }
                else if (info.path.IndexOf("EventService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    EventService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FASTOrderEntryWebService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    ClientWebService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FastDocumentService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocumentService.err500Count += info.count;
                }
                else if (info.path.IndexOf("RecordedDocWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    RecordedDocService.err500Count += info.count;
                }
                else if (info.path.IndexOf("WorkflowService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    WorkflowService.err500Count += info.count;
                }
                else if ((info.path.IndexOf("FASTSERVICEINTERFACE", StringComparison.OrdinalIgnoreCase) > 0) || (info.path.IndexOf("fastwebservice", StringComparison.OrdinalIgnoreCase) > 0))
                {
                    CustomerViewService.err500Count += info.count;
                }
                else if (info.path.IndexOf("DateDownWs", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DateDownService.err500Count += info.count;
                }
                else if (info.path.IndexOf("ClosingDisclosure", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    CDService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FASTTrust32WebService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    PaidCheckStatusService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FastUtilityService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    UtilityService.err500Count += info.count;
                }
                else if (info.path.IndexOf("docrequestws", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocRequestService.err500Count += info.count;
                }
                else if (info.path.IndexOf("CheckInfoWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    CheckInfoService.err500Count += info.count;
                }
                else if (info.path.IndexOf("UpdateDataHub", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DataHubService.err500Count += info.count;
                }
                else if (info.path.IndexOf("SecurityService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    SecurityService.err500Count += info.count;
                }
                else if (info.path.IndexOf("RTMEventLogDetailWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    RTMEventLogService.err500Count += info.count;
                }
                else if (info.path.IndexOf("AttachDocumentWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    AttachDocumentService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FastSearchResponseHandlerWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FASTSearchResponseService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FAFInternalBistroWS", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    FAFInternalBistroService.err500Count += info.count;
                }
                else if (info.path.IndexOf("FASTMDMService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    MDMService.err500Count += info.count;
                }
                else if (info.path.IndexOf("TempIntDocs", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    TempIntDocsService.err500Count += info.count;
                }

            }

            return ServiceInfoList;
        }

        public static string BuildStatsNDLV(List<ServiceInfo> newDataList)
        {
            ServiceInfo InterfaceService = new ServiceInfo(0, "Interface Service");
            ServiceInfo DocumentService = new ServiceInfo(0, "Document Service");
            ServiceInfo DeliveryService = new ServiceInfo(0, "Delivery Service");
            ServiceInfo ResolverService = new ServiceInfo(0, "Resolver Service");
            ServiceInfo RealECAnalyticsPDFService = new ServiceInfo(0, "Analytics2PDF Service");

            foreach (ServiceInfo info in newDataList)
            {
                if (info.path.IndexOf("InterfaceService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    InterfaceService.count += info.count;
                    InterfaceService.maxReq = info.maxReq;
                    InterfaceService.maxRes = info.maxRes;
                    InterfaceService.err500Count = info.err500Count;
                }
                else if (info.path.IndexOf("DocumentService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DocumentService.count += info.count;
                    DocumentService.maxRes = info.maxRes;
                    DocumentService.maxReq = info.maxReq;
                    DocumentService.err500Count = info.err500Count;
                }
                else if (info.path.IndexOf("DeliveryService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    DeliveryService.count += info.count;
                    DeliveryService.maxReq = info.maxReq;
                    DeliveryService.maxRes = info.maxRes;
                    DeliveryService.err500Count = info.err500Count;
                }
                else if (info.path.IndexOf("ResolverService", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    ResolverService.count += info.count;
                    ResolverService.maxRes = info.maxRes;
                    ResolverService.maxReq = info.maxReq;
                    ResolverService.err500Count = info.err500Count;
                }
                else if (info.path.IndexOf("NextGenProcessing", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    RealECAnalyticsPDFService.count += info.count;
                    RealECAnalyticsPDFService.maxRes = info.maxRes;
                    RealECAnalyticsPDFService.maxReq = info.maxReq;
                    RealECAnalyticsPDFService.err500Count = info.err500Count;
                }
            }

            List<ServiceInfo> ServiceInfoList = new List<ServiceInfo>();
            ServiceInfoList.Add(InterfaceService);
            ServiceInfoList.Add(DocumentService);
            ServiceInfoList.Add(DeliveryService);
            ServiceInfoList.Add(ResolverService);
            ServiceInfoList.Add(RealECAnalyticsPDFService);
            List<ServiceInfo> OrderedServiceInfoList = new List<ServiceInfo>();

            OrderedServiceInfoList = ServiceInfoList.OrderByDescending(srv => srv.count).ToList<ServiceInfo>();

            StringBuilder builder = new StringBuilder();

            foreach (ServiceInfo info in OrderedServiceInfoList)
            {
                builder.Append("['" + info.path + "','" + string.Format("{0:n0}", info.count) + "','" + string.Format("{0:n0}", info.err500Count) + "','" + info.maxReq + "','" + info.maxRes + "'],");
            }
            return builder.ToString();
        }

        public static string BuildStats(List<ServiceInfo> ServiceInfoList)
        {

            OrderedServiceInfoList = ServiceInfoList.OrderByDescending(srv => srv.count).ToList<ServiceInfo>();

            StringBuilder builder = new StringBuilder();

            foreach (ServiceInfo info in OrderedServiceInfoList)
            {
                builder.Append("['" + info.path + "','" + string.Format("{0:n0}", info.count) + "','" + string.Format("{0:n0}", info.ltOneSecondCount) + "','" + info.GetitOneSecondCountPct() + "','" + string.Format("{0:n0}", info.err500Count) + "','" + info.maxReq + "','" + info.maxRes + "'],");
            }
            return builder.ToString();
        }

        public static string BuildStatsSimple(List<ServiceInfo> ServiceInfoList)
        {

            OrderedServiceInfoList = ServiceInfoList.OrderByDescending(srv => srv.count).ToList<ServiceInfo>();

            StringBuilder builder = new StringBuilder();

            foreach (ServiceInfo info in OrderedServiceInfoList)
            {
                builder.Append("['" + info.path + "','" + string.Format("{0:n0}", info.count) + "'],");
            }
            return builder.ToString();
        }

    }
}
