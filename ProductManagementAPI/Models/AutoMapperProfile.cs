using AutoMapper;
using BusinessObjects;
using ShopDTO;

namespace ProductManagementAPI.Models
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {
        CreateMap<Product, ProductDTO>().ForMember(d => d.CategoryName, o => o.MapFrom(src =>src.Category.CategoryName));
        }

    }
}
