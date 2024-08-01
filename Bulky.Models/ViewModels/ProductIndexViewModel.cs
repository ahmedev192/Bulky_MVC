using System.Collections.Generic;

namespace Bulky.Models.ViewModels
{
    /// <summary>
    /// Represents a view model for displaying a list of products.
    /// </summary>
    public class ProductIndexViewModel
    {
        /// <summary>
        /// Gets or sets the list of products to be displayed.
        /// </summary>
        public IEnumerable<Product> Products { get; set; }
    }
}
