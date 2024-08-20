using Application.DTO.RequestDTO;
using Application.DTO.ResponseDTO;
using AutoMapper;
using Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers.ProductMap
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryRequestDTO,Category>()
                .ForMember(des=>des.Name,opt=>opt.MapFrom(src=>src.CategoryName)).ReverseMap();
            CreateMap<CategoryResposeDTO,Category>()
                .ForMember(des=>des.Name,opt=>opt.MapFrom(dest=>dest.CategoryName)).ReverseMap();   
        }
    }
}
