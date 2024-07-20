using System.ComponentModel.DataAnnotations.Schema;

namespace DPL.Models
{
    public class SubCategories
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
    }
}
