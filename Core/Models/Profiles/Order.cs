using AutoMapper;

namespace Hall.Core.Models.Profiles
{
     public class Order : Profile
     {
          public Order()
          {
               CreateMap<KitchenReturnOrder, ReturnOrder>();
               CreateMap<HallOrder, ReturnOrder>();
          }
     }
}
