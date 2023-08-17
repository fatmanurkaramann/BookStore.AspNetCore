using AutoMapper;
using BookStore.AspNetCore.ViewModels;
using Business.DTOs;
using DataAccess.Entities;

namespace BookStore.AspNetCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDto, BookListViewModel>().ReverseMap();


            //CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<Book, BookDto>()
                .ReverseMap();

            CreateMap<BookUpdateDto, Book>()
                .ReverseMap();


            CreateMap<Book, BookListDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => new AuthorDto { Firstname = src.Author.Firstname, Lastname = src.Author.Lastname }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new CategoryDto {  CategoryName = src.Category.CategoryName }))
                .ReverseMap();

            // Author türünden AuthorDto'ya dönüşümü belirtin
            CreateMap<Author, AuthorDto>().ReverseMap();

            // Category türünden CategoryDto'ya dönüşümü belirtin (varsayılan adı CategoryName ise)
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }

}
