using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TretaPractical.Models
{
    public class ProjectAssign
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeIdRef { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("Project")]
        public int ProjectIdRef { get; set; }
        public virtual Project Project { get; set; }    
        public string Status { get; set; }

    }
}
