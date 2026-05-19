using System.Collections.Generic;
using _27_FrontToBackSqlConnection.Models.Base;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductTag> ProductTags { get; set; } = new();
    }
}