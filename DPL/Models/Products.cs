using System.ComponentModel.DataAnnotations.Schema;

namespace DPL.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public int SubCategoryID { get; set; }
        [NotMapped]
        public string? SubCategoryName { get; set; }

        [NotMapped] public int Quantity { get; set; } = 1;
    }
}
