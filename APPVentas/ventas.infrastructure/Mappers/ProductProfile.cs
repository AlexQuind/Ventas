using AutoMapper;
using ventas.application.DTOs;
using ventas.domain.model;
using ventas.infrastructure.Entidades;

namespace ventas.application.Mappers
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			// Mapeo de Product a ProductDTO
			CreateMap<Product, ProductDTO>();
			// Mapeo de ProductDTO a Product
			CreateMap<ProductDTO, Product>();

			//Mapeo de productEntity a product
			CreateMap<ProductEntity, Product>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
				.ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

			//Mapeo de product a producyEntity
			// Mapeo de Product a ProductEntity
			CreateMap<Product, ProductEntity>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
				.ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));
		}
	}
}
