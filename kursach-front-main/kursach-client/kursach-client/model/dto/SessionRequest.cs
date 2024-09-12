using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model
{
    public class SessionRequest
    {
        public Guid id { get; set; }
        public DateTime startSession { get; set; }
        public DateTime? endSession { get; set; }
    }
}
