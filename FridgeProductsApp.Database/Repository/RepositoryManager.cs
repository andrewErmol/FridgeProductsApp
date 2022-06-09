using FridgeProductsApp.Contracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Database.Repository
{
    public class RepositoryManager
    {
        private FridgeProductsDbContext _fridgeProductsDbContext;
        private IFridgeRepository _fridgeRepository;
        private IFridgeProductRepository _fridgeProductRepository;
        private IProductRepository _productRepository;
        private IModelRepository _modelRepository;
        private IUserRepository _userRepository;

        public RepositoryManager(FridgeProductsDbContext fridgeProductsDbContext)
        {
            _fridgeProductsDbContext = fridgeProductsDbContext;
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_fridgeRepository == null)
                    _fridgeRepository = new FridgeRepository(_fridgeProductsDbContext);
                return _fridgeRepository;
            }
        }

        public IFridgeProductRepository FridgeProduct
        {
            get
            {
                if (_fridgeProductRepository == null)
                    _fridgeProductRepository = new FridgeProductRepository(_fridgeProductsDbContext);
                return _fridgeProductRepository;
            }
        }

        public IModelRepository Model
        {
            get
            {
                if (_modelRepository == null)
                    _modelRepository = new ModelRepository(_fridgeProductsDbContext);
                return _modelRepository;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_fridgeProductsDbContext);
                return _productRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_fridgeProductsDbContext);
                return _userRepository;
            }
        }

        public void Save() => _fridgeProductsDbContext.SaveChanges();
    }
}
