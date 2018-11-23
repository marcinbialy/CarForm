using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Controllers.Resources
{
    public class CarMarkResources
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CarModelResources> CarModels { get; set; }

        public CarMarkResources()
        {
            CarModels = new Collection<CarModelResources>();
        }
    }
}
