using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Controllers.Resources
{
    public class CarMarkResources : KeyValuePairResources
    {
        public ICollection<KeyValuePairResources> CarModels { get; set; }

        public CarMarkResources()
        {
            CarModels = new Collection<KeyValuePairResources>();
        }
    }
}
