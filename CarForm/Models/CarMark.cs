using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Models
{
    public class CarMark
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<CarModel> CarModels { get; set; }

        public CarMark()
        {
            CarModels = new Collection<CarModel>();
        }
    }
}
