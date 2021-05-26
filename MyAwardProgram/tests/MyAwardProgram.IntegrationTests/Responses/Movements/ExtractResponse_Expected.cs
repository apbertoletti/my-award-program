using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using MyAwardProgram.Domain.Aggregates.Orders.Entities;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyAwardProgram.IntegrationTests.Responses.Movements
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
    }
}
