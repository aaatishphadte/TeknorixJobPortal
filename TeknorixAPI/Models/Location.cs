using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeknorixAPI.Models
{
    public class Location
    {
        [Key]
       [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string State { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;
        [Required]
        public int Zip { get; set; }


    }
}
