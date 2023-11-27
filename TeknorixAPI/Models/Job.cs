using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknorixAPI.Models
{
    public class Job
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobID { get; set; }

        [Index(IsUnique = true)]
        [Required]
        public Guid Code { get; set; } 
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }
        public required Location Location { get; set; }
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
        public required Department Department { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }
        
        public DateTime ClosedDate { get; set; } 

    }
}
