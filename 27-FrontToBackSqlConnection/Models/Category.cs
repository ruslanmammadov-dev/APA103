using System.ComponentModel.DataAnnotations;
using _27_FrontToBackSqlConnection.Models.Base;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(30,ErrorMessage ="Max Length 30")]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
