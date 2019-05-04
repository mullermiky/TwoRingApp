using System;
using System.Collections.Generic;

namespace _2RingApp.Models
{
    public partial class ContactCallDetail
    {
        public decimal SessionId { get; set; }
        public short SessionSeqNum { get; set; }
        public short NodeId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UccxGmtOffset { get; set; }
        public DateTime? UccxLocalStartDateTime { get; set; }
        public DateTime? UccxLocalEndDateTime { get; set; }
        public DateTime InsertDateTime { get; set; }
        public short? ContactType { get; set; }
        public short? ContactDisposition { get; set; }
        public short? OriginatorType { get; set; }
        public string OriginatorDn { get; set; }
        public int? OriginatorId { get; set; }
        public short? DestinationType { get; set; }
        public string DestinationDn { get; set; }
        public int? DestinationId { get; set; }
        public int? ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public short? ConnectTime { get; set; }
        public bool? Transfer { get; set; }
        public bool? Conference { get; set; }
        public bool? Redirect { get; set; }
        public string CustomVariable1 { get; set; }
        public string CustomVariable2 { get; set; }
        public string CustomVariable3 { get; set; }
        public string CustomVariable4 { get; set; }
        public string CustomVariable5 { get; set; }
        public string CustomVariable6 { get; set; }
        public string CustomVariable7 { get; set; }
        public string CustomVariable8 { get; set; }
        public string CustomVariable9 { get; set; }
        public string CustomVariable10 { get; set; }
    }
}
