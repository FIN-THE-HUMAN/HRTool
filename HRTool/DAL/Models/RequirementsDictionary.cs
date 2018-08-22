using System;
using System.Collections.Generic;

namespace HRTool.DAL.Models
{
    public class RequirementsDictionary
    {
        //TODO: сформировать словари требований и обязанностей
        public Guid Id {get;set;}
        public Dictionary<int,string> Requirements = new Dictionary<int, string>(0);
    }
}