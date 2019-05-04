using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2RingApp.Models
{
    public class SpGetData
    {
        [Key]
        public string csqName { get; set; }
        public int loggedinagents { get; set; }
        public int availableagents { get; set; }
        public int numberOfCalls { get; set; }
        public int numberOfAbandonedCalls { get; set; }
        public int numberOfhandledCalls { get; set; }
    }
}
