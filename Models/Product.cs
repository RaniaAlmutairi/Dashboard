using System.ComponentModel.DataAnnotations;

namespace DashboardProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
