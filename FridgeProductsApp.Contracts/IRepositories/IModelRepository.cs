using FridgeProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Contracts.IRepositories
{
    public interface IModelRepository
    {
        IEnumerable<Model> GetAllModels(bool trackChanges);
        Model GetModel(Guid modelId, bool trackChanges);
        void CreateModel(Model model);
        void DeleteModel(Model model);
    }
}
