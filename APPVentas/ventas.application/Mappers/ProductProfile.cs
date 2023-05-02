using AutoMapper;
using ventas.application.DTOs;
using ventas.domain.model;

namespace ventas.application.Mappers
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductDTO>();
			CreateMap<ProductDTO, Product>();
		}
	}
}
