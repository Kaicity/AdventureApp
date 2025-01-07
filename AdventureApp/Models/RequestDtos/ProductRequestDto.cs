using System.ComponentModel.DataAnnotations;

namespace AdventureApp.Models.RequestDtos
{
    public class ProductRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
