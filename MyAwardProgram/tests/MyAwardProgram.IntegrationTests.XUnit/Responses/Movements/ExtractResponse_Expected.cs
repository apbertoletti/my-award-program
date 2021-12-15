using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using System;
using System.Text.Json.Serialization;

namespace MyAwardProgram.IntegrationTests.XUnit.Responses.Movements
{
    public class ExtractResponse_Expected
    {
        public DateTime Occurrence { get; set; }

        public MovementTypeEnum Type { get; set; }
        
        public int Dots { get; set; }

        [JsonPropertyName("due-date")]
        public DateTime? DueDate { get; set; }
        
        public string Product { get; set; }
        
        public string Partner { get; set; }

        [JsonPropertyName("new-prop")]
        public int NovaPropriedade { get; set; }
    }
}
