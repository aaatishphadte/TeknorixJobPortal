using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeknorixAPI.Models
{
    public class Jobs
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
        
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }
       
        public DateTime PostedDate { get; set; }

        public DateTime ClosedDate { get; set; }
    }
}
