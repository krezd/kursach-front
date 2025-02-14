using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class UpdateUserByAdminRequest
    {
        public long id { get; set; }
        public String position { get; set; }
        public String role { get; set; }

        public UpdateUserByAdminRequest(long id, String position, String role) {
            this.id = id;
            this.position = position;
            this.role = role;
        }
    }
}
