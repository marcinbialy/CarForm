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
            //Domain to API Resource
            CreateMap<CarMark, CarMarkResources>();
            CreateMap<CarMark, KeyValuePairResources>();
            CreateMap<CarModel, KeyValuePairResources>();
            CreateMap<Feature, KeyValuePairResources>();
            CreateMap<Vehicle, SaveVehicleResources>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResources { Name = v.ContactName, Email = v.Email, Phone = v.ContactPhone }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResources>()
                .ForMember(vr => vr.CarMark, opt => opt.MapFrom(v => v.CarModel.CarMark))
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResources { Name = v.ContactName, Email = v.Email, Phone = v.ContactPhone }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairResources { Id = vf.Feature.Id, Name = vf.Feature.Name})));


            //API Resource to Domain
            CreateMap<SaveVehicleResources, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.Email, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    // Remove unselected features
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach (var f in removedFeatures.ToList())
                        v.Features.Remove(f);

                    // Add new features
                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id });
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);
                });
        }
    }
}
