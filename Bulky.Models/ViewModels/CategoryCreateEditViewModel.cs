using System.ComponentModel.DataAnnotations;

namespace Bulky.Models.ViewModels
{
    /// <summary>
    /// Represents a view model for creating or editing a category.
    /// </summary>
    public class CategoryCreateEditViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name value cannot exceed 100 characters.")]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "The Display Order must be greater than zero.")]
        public int DisplayOrder { get; set; }
    }
}
