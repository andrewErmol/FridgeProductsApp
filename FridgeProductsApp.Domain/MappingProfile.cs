using AutoMapper;
using FridgeProductsApp.Domain.DTO.Fridge;
using FridgeProductsApp.Domain.DTO.FridgeProduct;
using FridgeProductsApp.Domain.DTO.Model;
using FridgeProductsApp.Domain.DTO.Product;
using FridgeProductsApp.Domain.DTO.User;
using FridgeProductsApp.Domain.Models;

namespace FridgeProductsApp.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>()
                .ForMember(f => f.ModelName, opt => opt.MapFrom(x => x.Model.Name))
                .ForMember(f => f.YearOfRelease, opt => opt.MapFrom(x => x.Model.YearOfRelease));
            CreateMap<FridgeForCreationDto, Fridge>();
            CreateMap<FridgeForUpdateDto, Fridge>();

            CreateMap<FridgeProduct, FridgeProductDto>()
                .ForMember(fp => fp.FridgeName, opt => opt.MapFrom(x => x.Fridge.Name))
                .ForMember(fp => fp.ProductName, opt => opt.MapFrom(x => x.Product.Name))
                .ForMember(fp => fp.Quantity, opt => opt.MapFrom(x => x.Quantity));
            CreateMap<FridgeProductForCreationDto, FridgeProduct>();
            CreateMap<FridgeProductForUpdateDto, FridgeProduct>();

            CreateMap<ModelForCreationDto, Model>();
            CreateMap<ModelForUpdateDto, Model>();

            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();

            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserForAuthenticationDto, User>();
        }
    }
}
