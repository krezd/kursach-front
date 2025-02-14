using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class ProcessDTO
    {
        public long Id { get; set; }
        public string ProcessName { get; set; }
        public List<ProcessUsage> usageTimes { get; set; }

        public ProcessStatus ProcessStatus { get; set; }
    }
}
