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
    public class AuthorMapping : Profile
    {
           public AuthorMapping()
        {
            
            CreateMap<Author, AuthorDTO>();

            CreateMap<AuthorDTO, Author>();
        }
    }
}
