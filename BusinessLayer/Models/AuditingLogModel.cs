using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class AuditingLogModel
    {
        public int LogId { get; set; }
        public string LogType { get; set; }
        public string LogName { get; set; }
        public string LogScreen { get; set; }
        public string ActionPerformed { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateString { get; set; }
        public string Misc { get; set; }
        public string IPAddress { get; set; }
    }

    public class AuditingLogDropModel
    {
        public string ID { get; set; }
        public string Title { get; set; }
    }
}
