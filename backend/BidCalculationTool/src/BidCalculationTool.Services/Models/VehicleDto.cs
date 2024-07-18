using System.Text.Json.Serialization;

namespace BidCalculationTool.Services.Models {
    public class VehicleDto {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("basePrice")]
        public decimal BasePrice { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("type")]
        public EnumVehicleType Type { get; set; }
    }
}
