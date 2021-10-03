using System;
namespace HistoryREST.DTOS
{

    public record CastleDto
    { 
    public Guid Id { get; init; }


    public string Name { get; init; }

    public string Location { get; init; }

    public decimal Year { get; init; }

    }

}

