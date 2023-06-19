using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Szkolenie3API.Contrats;
using Szkolenie3API.Data;
using Szkolenie3API.DTO.Cat;
using Szkolenie3API.DTO.Dog;
using Szkolenie3API.Repository;

namespace Szkolenie3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly ICatsRepository _catsRepository;
        private readonly IMapper _mapper;

        public CatsController(IMapper mapper, ICatsRepository catsRepository)
        {
            _mapper = mapper;
            this._catsRepository = catsRepository;
        }

        // GET: api/Cats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCatDto>>> Getcats()
        {
            var cats = await _catsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCatDto>>(cats);
            return Ok(records);
        }

        // GET: api/Cats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCatDto>> GetCat(int id)
        {
            var cat = await _catsRepository.GetAsync(id);

            if (cat == null)
            {
                return NotFound();
            }

            return _mapper.Map<GetCatDto>(cat);
        }

        // PUT: api/Cats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCat(int id, PutCatDto putCatDto)
        {
            if (id != putCatDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var cat = await _catsRepository.GetAsync(id);

            if (cat == null)
            {
                return NotFound();
            }
            _mapper.Map(putCatDto, cat);
            try
            {
                await _catsRepository.UpdateAsync(cat);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cat>> PostCat(BaseCatDto catDto)
        {
            var cat = _mapper.Map<Cat>(catDto);

            await _catsRepository.AddAsync(cat);

            return CreatedAtAction("GetCat", new { id = cat.Id }, cat);
        }

        // DELETE: api/Cats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            var cat = await _catsRepository.GetAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            await _catsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CatExists(int id)
        {
            return await _catsRepository.Exists(id);
        }
    }
}
