using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace mission6.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }

        // Non Required fields
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        public string? CopiedToPlex { get; set; }


        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}
