using System;
using System.ComponentModel.DataAnnotations;

namespace HistoryREST.DTOS
{
    public record UpdatingCastleDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public string Location { get; init; }
        [Required]
        [Range(1,2021)]
        public decimal Year { get; init; }
        }
    }
 
