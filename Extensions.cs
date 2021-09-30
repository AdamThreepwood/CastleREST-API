using System;
using HistoryREST.DTOS;
using HistoryREST.Entries;

namespace HistoryREST
{
    public static class Extensions
    {
        public static CastleDto AsDto(this Castle castle)
        {
            return new CastleDto
            {
                Id = castle.Id,
                Name = castle.Name,
                Location = castle.Location,
                Year = castle.Year,

            };
        
        }
    }
}
