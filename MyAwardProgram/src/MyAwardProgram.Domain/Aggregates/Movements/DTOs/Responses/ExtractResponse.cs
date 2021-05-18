using MyAwardProgram.Domain.Aggregates.Movements.Entities;
using System.Collections.Generic;

namespace MyAwardProgram.Domain.Aggregates.Movements.DTOs.Responses
{
    public class ExtractResponse
    {
        public List<Movement> ExtractUser { get; set; }
    }
}
