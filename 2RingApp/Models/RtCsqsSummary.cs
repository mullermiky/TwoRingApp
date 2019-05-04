using System;
using System.Collections.Generic;

namespace _2RingApp.Models
{
    public partial class RtCsqsSummary
    {
        public string Csqname { get; set; }
        public DateTime Enddatetime { get; set; }
        public int Oldestcontact { get; set; }
        public int Callswaiting { get; set; }
        public int Loggedinagents { get; set; }
        public int Workingagents { get; set; }
        public int Availableagents { get; set; }
        public int Unavailableagents { get; set; }
        public int Reservedagents { get; set; }
        public int Talkingagents { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
