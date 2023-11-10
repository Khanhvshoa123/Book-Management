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
    public class UserMapping : Profile
    {
        public UserMapping()
        {
           
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();




        }
    }
}
