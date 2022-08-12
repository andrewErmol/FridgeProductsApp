namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IRepositoryManager
    {
        IFridgeRepository Fridge { get; }
        IFridgeProductRepository FridgeProduct { get; }
        IModelRepository Model { get; }
        IProductRepository Product { get; }
        IUserRepository User { get; }
        void Save();
    }
}
