using cocop.Database;
using cocop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cocop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class manufacturersController : ControllerBase
    {
        private readonly DataDbContext _dbContext;

        public manufacturersController(DataDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        //get post put deleter

        [HttpGet]
        public async Task<ActionResult<List<manufacturers>>> getManufacturers()
        {
            var manufacturers = await _dbContext.manufacturers.ToListAsync();
            if (manufacturers.Count == 0) 
            {
                return NotFound();
            }
            return Ok(manufacturers);
        }

        //get by id
        [HttpGet("id")]
        public async Task<ActionResult<manufacturers>>getManufacturer(int id)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return Ok();
        }
        //Post
        [HttpPost]
        public async Task<ActionResult<manufacturers>> postManufacturers(manufacturers manufacturer)
        {
            _dbContext.manufacturers.Add(manufacturer);
            await _dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }

        //put
        [HttpPut]
        public async Task<ActionResult<manufacturers>> putManufacturer(int id, manufacturers manufacturer)
        {
            var manufacturers = await _dbContext.manufacturers.FindAsync(id);

            if (manufacturers == null)
            {
                return NotFound();
            }
            manufacturers.id = manufacturer.id;
            manufacturers.Title = manufacturer.Title;

            await _dbContext.SaveChangesAsync();

            return Ok(manufacturers);
        }

        //delete
        [HttpDelete]
        public async Task<ActionResult<manufacturers>> deleteManufacturer(int id)
        {
            var manufacturer = await _dbContext.manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            _dbContext.manufacturers.Remove(manufacturer);

            await _dbContext.SaveChangesAsync();

            return Ok(manufacturer);
        }
            }
}
