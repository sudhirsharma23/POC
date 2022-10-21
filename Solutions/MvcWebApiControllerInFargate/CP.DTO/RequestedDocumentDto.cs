namespace CP.DTO
{
    public class RequestedDocumentDto
    {
        public int RequestedDocumentId { get; set; }
        public int ConsumerDocumentMappingId { get; set; }
        public int PayoffDocId { get; set; }
        public string FriendlyName { get; set; }
        public string DisplayName { get; set; }
        public bool IsWidgetDisplayed { get; set; }
        public PostSigningEventType PostSigningEventType { get; set; }
        public string EncryptedConsumerDocumentMappingId { get; set; }
        public string EncryptedFastFileNumber { get; set; }
        public string EncryptedPayoffDocId { get; set; }
    }

    public enum PostSigningEventType
    {
        None = 0,
        LiveSign = 1,
        UploadSurvey = 2,
        UploadTitlePolicy = 3,
    }
}