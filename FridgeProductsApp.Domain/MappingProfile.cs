using AutoMapper;
using FridgeProducts.Domain.Models;
using FridgeProductsApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProductsApp.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fridge, FridgeDto>()
                .ForMember(f => f.Model,
                opt => opt.MapFrom(x => string.Join(' ', x.Model.Name, x.Model.YearOfRelease)));
            CreateMap<FridgeProduct, FridgeProductDto>()
                .ForMember(fp => fp.FridgeName, opt => opt.MapFrom(x => $"{x.Fridge.Name}"))
                .ForMember(fp => fp.ProductName, opt => opt.MapFrom(x => $"{x.Product.Name}"))
                .ForMember(fp => fp.ProductQuantity, opt => opt.MapFrom(x => $"{x.Quantity}"));
        }
    }
}
