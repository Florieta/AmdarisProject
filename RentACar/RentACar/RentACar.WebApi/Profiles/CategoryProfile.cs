﻿using AutoMapper;
using RentACar.Application.Categories.Commands.Create;
using RentACar.Application.Categories.Commands.Update;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Category;

namespace RentACar.WebApi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<AddCategoryDto, CreateCategory>();
            CreateMap<EditCategoryDto, UpdateCategory>();
        }
    }
}