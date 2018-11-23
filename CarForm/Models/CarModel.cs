using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarForm.Models
{
    [Table("Models")]
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public CarMark CarMark { get; set; }
        public int CarMarkId { get; set; }

    }
}
