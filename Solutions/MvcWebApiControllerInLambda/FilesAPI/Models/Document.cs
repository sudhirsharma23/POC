using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilesAPI
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ViewedOn { get; set; }
    }
}