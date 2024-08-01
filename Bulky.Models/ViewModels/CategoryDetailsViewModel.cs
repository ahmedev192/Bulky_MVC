namespace Bulky.Models.ViewModels
{
    /// <summary>
    /// Represents a view model for displaying detailed information about a category.
    /// </summary>
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
