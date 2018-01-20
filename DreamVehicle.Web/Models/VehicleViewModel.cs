namespace DreamVehicle.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.Constants;

    public class VehicleViewModel
    {
        [Required(ErrorMessage = RequiredValidationErrorMessage)]
        [Display(Name = ModelName)]
        public string Model { get; set; }

        [Required(ErrorMessage = RequiredValidationErrorMessage)]
        [Range(1800, 2100, ErrorMessage = RangeValidationErrorMessage)]
        [Display(Name = ManufacturedYearName)]
        public int ManufacturedYear { get; set; }

        [Required(ErrorMessage = RequiredValidationErrorMessage)]
        [Range(1, 1000, ErrorMessage = RangeValidationErrorMessage)]
        [Display(Name = HorsePowerName)]
        public int HorsePower { get; set; }

        [Required(ErrorMessage = RequiredValidationErrorMessage)]
        [Display(Name = ImporterName)]
        public string Importer { get; set; }

        [Required(ErrorMessage = RequiredValidationErrorMessage)]
        [Display(Name = DescriptionName)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = StringLengthValidationErrorMessage)]
        public string Description { get; set; }
    }
}
