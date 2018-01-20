namespace DreamVehicle.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;

    using static Infrastructure.Constants.WebConstants;

    public static class TempDataDictionaryExtensions
    {
        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[TempDataSuccessMessageKey] = message;
        }
    }
}
