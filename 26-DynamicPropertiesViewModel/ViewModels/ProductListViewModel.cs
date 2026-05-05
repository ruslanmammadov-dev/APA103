using _26_DynamicPropertiesViewModel.Models;

namespace _26_DynamicPropertiesViewModel.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public string CategoryName { get; set; }
        public int TotalCount => Products.Count;
    }
}