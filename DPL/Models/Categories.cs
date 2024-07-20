namespace DPL.Models
{
    public class Categories
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageName { get; set; }
        public string? ImageFormat { get; set; }
    }
}
