using System;
using System.Collections.Generic;
using System.Linq;
using HistoryREST.DTOS;
using HistoryREST.Entries;
using HistoryREST.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HistoryREST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CastlesController : ControllerBase
    {
        private readonly ICastlesRepository repository;
        
        public CastlesController(ICastlesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<CastleDto> GetCastles()
        {
            var castles = repository.GetCastles().Select(castle => castle.AsDto());

            return castles;

        }
        [HttpGet("{id}")]
        public ActionResult<CastleDto> GetCastle(Guid id)
        {
            var castle = repository.GetCastle(id);

            if(castle is null)
            {

                return NotFound();
            }

            return castle.AsDto();
        }
    }
}
