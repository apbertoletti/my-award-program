using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using System;

namespace MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses
{
    public class ExtractResponse
    {
        public DateTime Occurrence { get; set; }
        public MovementTypeEnum Type { get; set; }
        public int Dots { get; set; }
        public DateTime? DueDate { get; set; }
        public string Product { get; set; }
        public string Partner { get; set; }
    }
}
