using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarForm.Controllers.Resources;
using CarForm.Data;
using CarForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarForm.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public FeaturesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/features")]
        public IEnumerable<FeatureResources> Index()
        {
            var features = _context.Features.ToList();
            return mapper.Map<List<Feature>, List<FeatureResources>>(features);
        }
    }
}