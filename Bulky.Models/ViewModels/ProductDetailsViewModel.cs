using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models.ViewModels
{
    /// <summary>
    /// Represents a view model for displaying detailed information about a product.
    /// </summary>
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }

        public double ListPrice { get; set; }

        public double Price { get; set; }

        public double Price50 { get; set; }

        public double Price100 { get; set; }

        public string CategoryName { get; set; }
        [ValidateNever]

        public string ImageUrl { get; set; }
    }
}
