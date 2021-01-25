using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPLOM.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Manager { get; set; }
        public string Student { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Path { get; set; }
        public DateTime? DateChange { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public string Subject { get; set; }
    }
}