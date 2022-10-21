using System;

namespace CP.DTO
{
    public class LinkTransactionsDto
    {
        public LinkTransactionsResult LinkTransactionsResult { get; set; }
        public bool EulaRequired { get; set; }
    }

    public enum LinkTransactionsResult
    {
        FilesLinked = 0,
        LinkedToAnotherEagleId = 1,
        OnlyDeactivatedFiles = 2,
        NoFilesLinked = 3
    }
}
