using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace mission6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public string Director { get; set; }

        public string Rating { get; set; }

        [Required]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required]
        public string? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
