using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignalRDbUpdates.Models
{
    public class Messages
    {
        public int ID { get; set; }

        public string Update { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
