using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    /// <summary>
    /// Represents a category in the system.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The Name value cannot exceed 100 characters.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the display order of the category.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "The Display Order must be greater than zero.")]
        public int DisplayOrder { get; set; }
    }
}
