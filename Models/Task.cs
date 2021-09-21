using System;

namespace laba1.Models
{
    public class Task
    {
        public Task ()
        {

        }

        public int TaskID { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string Payment { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public int DepartmentID  { get; set; }

        public virtual Department Department { get; set; }
    }
}
