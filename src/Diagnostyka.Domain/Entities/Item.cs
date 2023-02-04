using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diagnostyka.Domain.Entities
{
    [Index(nameof(Kod), IsUnique = true)]
    [Index(nameof(Nazwa), IsUnique = true)]
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(12)]
        public string Kod { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nazwa { get; set; }
        [Required]
        [ForeignKey("KolorId")]
        public int KolorId { get; set; }

        public string Uwagi { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
