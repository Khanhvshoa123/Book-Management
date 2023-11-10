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
    public class PublisherMapping : Profile
    {
        public PublisherMapping()
        {
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<PublisherDTO, Publisher>();
        }
    }
}
