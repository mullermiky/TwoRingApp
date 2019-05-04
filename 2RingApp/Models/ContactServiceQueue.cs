using System;
using System.Collections.Generic;

namespace _2RingApp.Models
{
    public partial class ContactServiceQueue
    {
        public int ContactServiceQueueId { get; set; }
        public string CsqName { get; set; }
        public bool Active { get; set; }
        public int RecordId { get; set; }
        public int? ResourceGroupId { get; set; }
        public int? SkillGroupId { get; set; }
        public short ResourcePoolType { get; set; }
        public short QueueType { get; set; }
        public DateTime InsertDateTime { get; set; }
    }
}
