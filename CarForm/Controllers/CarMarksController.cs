using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarForm.Controllers.Resources;
using CarForm.Data;
using CarForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarForm.Controllers
{
    public class CarMarksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public CarMarksController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/carmarks")]
        public async Task<IEnumerable<CarMarkResources>> Index()
        {
            var marks = await _context.CarMarks.Include(m => m.CarModels).ToListAsync();
            return mapper.Map<List<CarMark>, List<CarMarkResources>>(marks);
        }
    }
}