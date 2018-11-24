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
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public VehiclesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleResources vehicleResources)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = await _context.CarModels.FindAsync(vehicleResources.CarModelId);
            if (model == null)
            {
                ModelState.AddModelError("CarModelId", "Invalid CarModelId");
                return BadRequest(ModelState);
            }
             

            var vehicle = mapper.Map<VehicleResources, Vehicle>(vehicleResources);
            vehicle.LastUpdate = DateTime.Now;

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleFeature>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VehicleResources vehicleResources)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await _context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<VehicleResources, Vehicle>(vehicleResources, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleFeature>(vehicle);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            _context.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var vehicle = await _context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResources>(vehicle);

            return Ok(vehicleResource);
        }
    }
}