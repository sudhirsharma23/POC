using Newtonsoft.Json;

namespace CP.DTO.WorkflowError
{
    public class WorkflowErrorDtoV2
    {
        [JsonProperty("values")]
        public ErrorValues Values { get; set; }
    }

    public class ErrorValues
    {
        public string ErrorMessage { get; set; }
        public string ErrorLogId { get; set; }
    }
}
