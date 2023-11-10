using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Mapping
{
    public class BookMapping : Profile
    { 
        public BookMapping()
        {
            CreateMap<Book, BookDTO>()
                 .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(src => src.PublisherDate));
            
            CreateMap<BookDTO, Book>()
                 .ForMember(dest => dest.PublisherDate, opt => opt.MapFrom(src => src.PublishedDate));


        }
    }
}
