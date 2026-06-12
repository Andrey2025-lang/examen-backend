using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackerRank1.Entities
{
    [Table("Fraudes")]
    public class Fraud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Los detalles del impostor son obligatorios")]
        public string ImpostorDetails { get; set; }

        public string ContactInfo { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}