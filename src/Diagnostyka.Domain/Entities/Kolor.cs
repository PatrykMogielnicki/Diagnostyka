using System.ComponentModel.DataAnnotations;

namespace Diagnostyka.Domain.Entities
{
    public class Kolor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public bool Active { get; set; } = false;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
