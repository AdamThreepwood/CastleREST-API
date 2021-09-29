using System;
using System.Collections.Generic;
using HistoryREST.Entries;

namespace HistoryREST.Repositories
{
    public interface ICastlesRepository
    {
        Castle GetCastle(Guid id);

        IEnumerable<Castle> GetCastles();
    }

}
