using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Coracao.Domain.Models.InternalModels.FlowModels
{
    public class BookingRequestModel
    {
        [Required]
        [JsonProperty("year")]
        public string Year { get; set; }

        [Required]
        [JsonProperty("apartment")]
        public string Apartment { get; set; }

        [Required]
        [JsonProperty("weekNumber")]
        public string WeekNumber { get; set; }

        [Required]
        [JsonProperty("periodInWeeks")]
        public string PeriodInWeeks { get; set; }

        [Required]
        [JsonProperty("numberOfAdults")]
        public string NumberOfAdults { get; set; }
    }
}