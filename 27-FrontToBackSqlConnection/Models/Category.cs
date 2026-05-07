using _27_FrontToBackSqlConnection.Models.Base;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
