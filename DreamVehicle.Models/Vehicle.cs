namespace DreamVehicle.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1800, 2100)]
        public int ManufacturedYear { get; set; }

        [Range(1, 1000)]
        public int HorsePower { get; set; }

        [Required]
        public string Importer { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }
    }
}
