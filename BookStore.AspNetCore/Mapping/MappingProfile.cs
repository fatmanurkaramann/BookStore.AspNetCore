using AutoMapper;
using BookStore.AspNetCore.Models;
using BookStore.AspNetCore.ViewModels;

namespace BookStore.AspNetCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookViewModel>().ReverseMap();
        }
    }
}
