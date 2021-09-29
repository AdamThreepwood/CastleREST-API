using System;
namespace HistoryREST.Entries
{
    public record Castle
    {
        public Guid Id { get; init; }


        public string Name { get; init; }

        public string Location { get; init; }

        public decimal Year { get; init; }
        
    }

}

