namespace FridgeProductsApp.Domain.DTO.Fridge
{
    public class FridgeWithQuantityNameOfProductsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string ModelName { get; set; }
        public int YearOfRelease { get; set; }
        public int QuantityNameOfProducts { get; set; }
    }
}
