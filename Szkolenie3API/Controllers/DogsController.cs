using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Szkolenie3API.Contrats;
using Szkolenie3API.Data;
using Szkolenie3API.DTO.Dog;

namespace Szkolenie3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDogsRepository _dogsRepository;

        public DogsController(IMapper mapper, IDogsRepository dogsRepository)
        {
            _mapper = mapper;
            this._dogsRepository = dogsRepository;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDogDto>>> Getdogs()
        {
            var dogs = await _dogsRepository.GetAllAsync();
            var records = _mapper.Map<List<GetDogDto>>(dogs);
            return Ok(records);
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDogDto>> GetDog(int id)
        {
            var dog = await _dogsRepository.GetAsync(id);

            if (dog == null)
            {
                return NotFound();
            }
            return _mapper.Map<GetDogDto>(dog);
        }

        // PUT: api/Dogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, PutDogDto putDogDto)
        {
            if(id != putDogDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var dog = await _dogsRepository.GetAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            _mapper.Map(putDogDto, dog);
            try
            {
                await _dogsRepository.UpdateAsync(dog);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DogExists(id))
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

        // POST: api/Dogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(BaseDogDto dogDto)
        {
            var dog = _mapper.Map<Dog>(dogDto);

            await _dogsRepository.AddAsync(dog);

            return CreatedAtAction("GetDog", new { id = dog.Id }, dog);
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            var dog = await _dogsRepository.GetAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            await _dogsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> DogExists(int id)
        {
            return await _dogsRepository.Exists(id);
        }
    }
}
