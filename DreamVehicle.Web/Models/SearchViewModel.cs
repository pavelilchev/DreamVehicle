namespace DreamVehicle.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.Constants.ValidationConstants;

    public class SearchViewModel
    {
        [Display(Name = DescriptionName)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = StringLengthValidationErrorMessage)]
        public string Searched { get; set; }

        [Display(Name = ImporterName)]
        public string Importer { get; set; }

        public List<SelectListItem> AllImporters { get; set; }
    }
}
