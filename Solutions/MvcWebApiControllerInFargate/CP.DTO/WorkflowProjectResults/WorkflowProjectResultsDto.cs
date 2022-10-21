using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CP.DTO.WorkflowProjectResults
{
    public class WorkflowProjectResultsDto
    {
        [JsonProperty("formGuid")]
        public Guid FormGuid { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("submissions")]
        public List<Submission> Submissions { get; set; }
    }

    public class Submission
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("completionTimeUTC")]
        public DateTimeOffset CompletionTimeUtc { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("workflowInProgress")]
        public bool WorkflowInProgress { get; set; }

        [JsonProperty("runId")]
        public Guid RunId { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("answer")]
        public Answer Answer { get; set; }
    }

    public class Answer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}