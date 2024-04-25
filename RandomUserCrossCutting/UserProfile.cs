using AutoMapper;
using RandomUser.Domain.Entities;

namespace RandomUserCrossCutting
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RandomicUser, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Login.Uuid))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name.First} {src.Name.Last}"))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => ReturnFullAddress(src.Location)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.Cell, opt => opt.MapFrom(src => src.Cell))
                .ForMember(dest => dest.PictureMedium, opt => opt.MapFrom(src => src.Picture.Medium))
                .ForMember(dest => dest.PictureLarge, opt => opt.MapFrom(src => src.Picture.Large))
                .ForMember(dest => dest.PictureThumbnail, opt => opt.MapFrom(src => src.Picture.Thumbnail))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Login.Password));
        }

        private string ReturnFullAddress(RandomicUserLocation location)
        {
            return $"{location.Street.Number} {location.Street.Name}, {location.City}, {location.State}, {location.Country}, {location.Postcode}.";
        }
    }
}
