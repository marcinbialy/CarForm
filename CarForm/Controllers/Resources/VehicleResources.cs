using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Controllers.Resources
{
    public class VehicleResources
    {
        public int Id { get; set; }
        public KeyValuePairResources CarModel { get; set; }
        public KeyValuePairResources CarMark { get; set; }
        public bool IsRegistered { get; set; }
        public ContactResources Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<KeyValuePairResources> Features { get; set; }

        public VehicleResources()
        {
            Features = new Collection<KeyValuePairResources>();
        }
    }
}
