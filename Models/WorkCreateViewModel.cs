using System;
using System.ComponentModel.DataAnnotations;

namespace laba1.Models
{
    public class WorkCreateViewModel
    {
        public WorkCreateViewModel()
        {

        }

        public int WorkID { get; set; }
        [Required(ErrorMessage = "Write ClientName")]
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string Payment { get; set; }
        [Range(typeof(DateTime), "01.01.2021", "01.01.2200", ErrorMessage = "Date should be between {1} and {2} .")]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Write Description")]
        public string Description { get; set; }
        public int DepartmentID  { get; set; }

        [Required(ErrorMessage = "Write Department")]
        public string DepartmentName { get; set; }
        
        public virtual Department Department { get; set; }
    }
}
