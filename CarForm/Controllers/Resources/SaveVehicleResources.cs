using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Controllers.Resources
{

    public class SaveVehicleResources
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactResources Contact { get; set; }

        public ICollection<int> Features { get; set; }

        public SaveVehicleResources()
        {
            Features = new Collection<int>();
        }
    }
}
