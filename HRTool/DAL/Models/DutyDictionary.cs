using System;
using System.Collections;
using System.Collections.Generic;

namespace HRTool.DAL.Models
{
    public class DutyDictionary
    {
        //TODO: сформировать словари требований и обязанностей
        public Guid Id {get;set;}
        Dictionary<int,string> Duties = new Dictionary<int, string>(0);
    }
}