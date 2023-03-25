using AutoMapper;
using Library.Core.Models.Dto;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core;
public class LibraryProfile : Profile
{
    public LibraryProfile()
    {
        CreateMap<User, LoginUserDto>().ReverseMap();

        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookForCreateDto>().ReverseMap();
    }
}
