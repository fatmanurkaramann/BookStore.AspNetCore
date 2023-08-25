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
            CreateMap<UserSignUpVM, AppUser>().ReverseMap();

            //book

            CreateMap<BookDto, BookListViewModel>().ReverseMap();

            CreateMap<Book, BookDto>()
                .ReverseMap();

            CreateMap<BookUpdateDto, Book>()
                .ReverseMap();

            CreateMap<Book, BookListDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => new AuthorDto
                { Firstname = src.Author.Firstname, Lastname = src.Author.Lastname }))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new CategoryDto {  CategoryName = src.Category.CategoryName }))
                .ReverseMap();


            CreateMap<Author, AuthorDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<UniversityDto, University>().ReverseMap();
            CreateMap<University, UniversityDto>().ReverseMap();


            CreateMap<CreateAuthorDto, Author>().ReverseMap();


        }
    }

}
