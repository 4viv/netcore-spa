using AutoMapper;
using Model;
using Model.DTOs;
using Service.Commons;

namespace Core.Api.Config
{
    // Esta Clase va a configurar nuestros mapeos para que la clase Client se vaya en automatico a ClientDto
    public class AutoMapperConfig : Profile
    {
        //instalamos el paquete de AutoMapper.Extensions.Microsoft.Depen en el proyecto de coreApi para poder inyectar la dependencia map
        public AutoMapperConfig() 
        {
            CreateMap<Client, ClientDto>();
            CreateMap<DataCollection<Client>, DataCollection<ClientDto>>();

            CreateMap<Product, ProductDto>();
            CreateMap<DataCollection<Product>, DataCollection<ProductDto>>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<DataCollection<Order>, DataCollection<OrderDto>>();

            // Order creation
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();
        }
    }
}
