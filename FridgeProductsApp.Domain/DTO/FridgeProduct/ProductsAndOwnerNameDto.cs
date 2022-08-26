namespace FridgeProductsApp.Domain.DTO.FridgeProduct
{
    public class ProductsAndOwnerNameDto
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public string FridgeName { get; set; }
        public List<string> Products { get; set; }
    }
}
