using System;
using System.Collections.Generic;

namespace _2RingApp.Models
{
    public partial class UccxTimeZone
    {
        public int Id { get; set; }
        public DateTime? UccxLocalDateTime { get; set; }
        public int? UccxGmtOffsetInMinutes { get; set; }
    }
}
