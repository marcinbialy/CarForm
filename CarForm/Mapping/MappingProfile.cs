using AutoMapper;
using CarForm.Controllers.Resources;
using CarForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarMark, CarMarkResources>();
            CreateMap<CarModel, CarModelResources>();
            CreateMap<Feature, FeatureResources>();
        }
    }
}
