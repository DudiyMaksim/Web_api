namespace Web_api.BLL.Dtos.Product
{
    public class CreateProductDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }
    }
}
