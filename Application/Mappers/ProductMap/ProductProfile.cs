using AutoMapper;
using Domain.Product;
using Application.DTO.RequestDTO;
using Microsoft.AspNetCore.Http;
using Infrastructure.File.Interface;
using Application.DTO.ResponseDTO;
using AutoMapper.Configuration.Conventions;

namespace Application.Mappers.ProductMap
{
    public class ProductProfile : Profile
    {
        

        public ProductProfile()
        {
            
            CreateMap<ProductRequestDTO, Product>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<ProductResposneDTO, Product>()
                .ForMember(des=>des.Name, opt => opt.MapFrom(src=>src.ProductName))
                .ForMember(des=>des.Image,opt=>opt.MapFrom(src=>src.ImagePath))
                .ForMember(des=>des.Id,opt=>opt.MapFrom(src=>src.ProductId))
                .ReverseMap();
            CreateMap<ProductUpdateRequestDTO, Product>().
                ForMember(dest => dest.Image, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
