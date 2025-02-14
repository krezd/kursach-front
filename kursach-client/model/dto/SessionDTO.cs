using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class SessionDTO
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartSession { get; set; }
        public DateTimeOffset? EndSession { get; set; }
    }
}
