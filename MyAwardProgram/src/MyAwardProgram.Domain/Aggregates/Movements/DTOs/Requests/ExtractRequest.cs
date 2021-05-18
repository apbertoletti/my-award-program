using MyAwardProgram.Domain.Aggregates.Movements.Enums;
using System;

namespace MyAwardProgram.Domain.Aggregates.Movements.DTOs.Requests
{
    public class ExtractRequest
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovementTypeEnum Type { get; set; }
    }
}