using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication1.Helpers
{
 public  class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, ResponseDTO>()
              .ForMember(c => c.Category, m => m.MapFrom(s => s.Category.Name))
              .ForMember(c => c.MeasureUnit,m => m.MapFrom(s =>  s.MeasureUnit.Name));


        }


    }
}
