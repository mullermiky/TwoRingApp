using System;
using System.Collections.Generic;

namespace _2RingApp.Models
{
    public partial class ContactQueueDetail
    {
        public decimal SessionId { get; set; }
        public short SessionSeqNum { get; set; }
        public short NodeId { get; set; }
        public int TargetId { get; set; }
        public short TargetType { get; set; }
        public short QIndex { get; set; }
        public short? Disposition { get; set; }
        public bool? MetServiceLevel { get; set; }
        public DateTime StartDateTime { get; set; }
        public int? Queuetime { get; set; }
        public DateTime InsertDateTime { get; set; }
        public int? UccxGmtOffset { get; set; }
        public DateTime? UccxLocalStartDateTime { get; set; }
    }
}
