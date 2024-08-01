using System.Collections.Generic;

namespace Bulky.Models.ViewModels
{
    /// <summary>
    /// Represents a view model for displaying a list of categories.
    /// </summary>
    public class CategoryIndexViewModel
    {
        /// <summary>
        /// Gets or sets the list of categories to be displayed.
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }
    }
}
