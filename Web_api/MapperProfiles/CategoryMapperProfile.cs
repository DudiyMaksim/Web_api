using AutoMapper;
using Web_api.BLL.Dtos.Category;
using Web_api.BLL.Dtos.Product;
using Web_api.BLL.Services.Category;
using Web_api.DAL.Entities;

namespace Web_api.MapperProfiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            // CreateCategoryDto -> CategoryEntity
            CreateMap<CreateCategoryDto, CategoryEntity>()
                .ForMember(dest => dest.NormalizedName, opt => opt.MapFrom(src => src.Name.ToUpper()))
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            // UpdateCategoryDto -> CategoryEntity
            CreateMap<UpdateCategoryDto, CategoryEntity>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            // CategoryEntity -> CategoryDto
            CreateMap<CategoryEntity, CategoryDto>();

            CreateMap<CreateProductDto, ProductEntity>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());  // Ігноруємо категорії для створення продукту

            CreateMap<UpdateProductDto, ProductEntity>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());  // Ігноруємо категорії для оновлення продукту

            CreateMap<ProductEntity, ProductDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name).ToList()));
        }
    }
}
