using System;
using System.Collections.Generic;
using HistoryREST.Entries;
using HistoryREST.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HistoryREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CastlesController : ControllerBase
    {
        private readonly InMemCastlesRepository repository;
        
        public CastlesController()
        {
            repository = new InMemCastlesRepository();
        }

        [HttpGet]
        public IEnumerable<Castle> GetCastles()
        {
            var castles = repository.GetCastles();
            return castles;

        }
        [HttpGet("{id}")]
        public ActionResult<Castle> GetCastle(Guid id)
        {
            var castle = repository.GetCastle(id);

            if(castle is null)
            {

                return NotFound();
            }

            return castle;
        }
    }
}
