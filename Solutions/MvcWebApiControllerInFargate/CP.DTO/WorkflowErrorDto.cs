using Newtonsoft.Json;

namespace CP.DTO
{
    public class WorkflowErrorDto
    {
        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public string ErrorLogId { get; set; }
    }
}