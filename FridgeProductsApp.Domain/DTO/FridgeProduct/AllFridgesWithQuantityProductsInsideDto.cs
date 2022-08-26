namespace FridgeProductsApp.Domain.DTO.FridgeProduct
{
    public class AllFridgesWithQuantityProductsInsideDto
    {
        public Guid FridgeId { get; set; }
        public string FridgeName { get; set; }
        public int Quantity { get; set; }
    }
}
