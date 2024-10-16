using System.ComponentModel.DataAnnotations;

namespace TravelUp.Models
{
    public class Item
    {
        [Key] // Mark 'Id' as the primary key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }

}
