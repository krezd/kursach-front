using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class ProcessUsage
    {
        public long? id { get; set; }
        public DateTimeOffset startTime { get; set; }
        public DateTimeOffset? endTime { get; set; }
    }
}
