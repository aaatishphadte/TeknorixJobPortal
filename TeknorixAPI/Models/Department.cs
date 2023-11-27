using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeknorixAPI.Models
{
    public class Department
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
       
    }
}
