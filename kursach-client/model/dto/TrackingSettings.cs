using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class TrackingSettings
    {
        public long id { get; set; }
        public int sendTimeMin { get; set; }
        public int scanTimeSec { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
