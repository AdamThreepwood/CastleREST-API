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
        [HttpPost]
        public ActionResult<CastleDto> CreateCastle(UpdateCastleDto castleDto)
        {
            Castle castle = new()
            {
                Id = Guid.NewGuid(),
                Name = castleDto.Name,
                Location = castleDto.Location,
                Year = castleDto.Year,
            };

            repository.CreateCastle(castle);

            return CreatedAtAction(nameof(GetCastle), new { id = castle.Id }, castle.AsDto());
        }
        [HttpPut("{id}")]
        public ActionResult UpdatingCastle(Guid id, UpdatingCastleDto castleDto)
        {
            var existingCastle = repository.GetCastle(id);

            if(existingCastle is null)
            {
                return NotFound();
            }
            Castle updatedCastle = existingCastle with
            {
                Name = castleDto.Name,
                Location = castleDto.Location,
                Year = castleDto.Year,
            };
            repository.UpdatingCastle(updatedCastle);

            return NoContent();

        }
        [HttpDelete("{id}")]]
        public ActionResult DeleteCastle(Guid id)
        {
            var existingCastle = repository.GetCastle(id);

            if (existingCastle is null)
            {
                return NotFound();
            }

            repository.DeleteCastle(id);
            return NoContent();
        }

    }
}
