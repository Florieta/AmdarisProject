using AutoMapper;
using RentACar.Application.Orders.Commands.Create;
using RentACar.Application.Orders.Commands.Update;
using RentACar.Domain.Entitites;
using RentACar.WebApi.ViewModels.Order;

namespace RentACar.WebApi.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, GetOrderViewModel>();
            CreateMap<AddOrderModel, CreateOrder>();
            CreateMap<EditOrderViewModel, UpdateOrder>();
        }
    }
}
