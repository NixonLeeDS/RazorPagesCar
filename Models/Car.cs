using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCar.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Required]
        public string carName { get; set; }

        [Required]
        [Display(Name = "Manufacture Date")]
        public DateTime ManufactureDate { get; set; }

        [Required]
        public string Type { get; set; }
        [Column(TypeName = "decimal(18, 2)")]

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Availability { get; set; }

    }
}
