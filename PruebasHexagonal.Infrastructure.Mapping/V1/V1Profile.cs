using AutoMapper;
using PruebasHexagonal.Application.Communication.V1.ViewModels;
using PruebasHexagonal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PruebasHexagonal.Infrastructure.Mapping.V1
{
    public class V1Profile : Profile
    {
        public V1Profile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
