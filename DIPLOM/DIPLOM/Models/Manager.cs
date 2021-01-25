using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIPLOM.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }

    }
}