using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class SessionView
    {
        public Guid Id { get; set; }
        public string StartDate { get; set; } // Отформатированная дата начала
        public string EndDate { get; set; }   // Отформатированная дата окончания
        public string Duration { get; set; }  // Продолжительность
    }
}
