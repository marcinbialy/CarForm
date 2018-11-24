using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Controllers.Resources
{

    public class VehicleResources
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }

        public bool IsRegistered { get; set; }
        
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}
