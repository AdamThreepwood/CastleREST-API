using System;
using System.Collections.Generic;
using System.Linq;
using HistoryREST.Entries;

namespace HistoryREST.Repositories
{

    public class InMemCastlesRepository : ICastlesRepository
    {
        private readonly List<Castle> castles = new()
        {

            new Castle { Id = Guid.NewGuid(), Name = "Tjolöholms slott", Location = "Kungsbacka", Year = 1898 },
            new Castle { Id = Guid.NewGuid(), Name = "Bohus fästning", Location = "Kungälv", Year = 1308 },
            new Castle { Id = Guid.NewGuid(), Name = "Edo castle", Location = "Tokyo", Year = 1457 },
            new Castle { Id = Guid.NewGuid(), Name = "Heidelberg schloss", Location = "Heidelberg", Year = 1214 },

        };

        public IEnumerable<Castle> GetCastles()

        {
            return castles;
        }

        public Castle GetCastle(Guid id)

        {

            return castles.Where(castle => castle.Id == id).SingleOrDefault();
        }

        public void CreateCastle(Castle castle)
        {
            castles.Add(castle);
        }

        public void UpdatingCastle(Castle castle)
        {
            var index = castles.FindIndex(existingCastle => existingCastle.Id == castle.Id);
            castles[index] = castle;
        }

        public void DeleteCastle(Guid id)
        {
            var index = castles.FindIndex(existingCastle => existingCastle.Id == id);

            castles.RemoveAt(index);
        }
    }

}

 