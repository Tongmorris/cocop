using cocop.Database;
using cocop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cocop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devicesController : ControllerBase
    {
        private readonly DataDbContext _dbContext;

        public devicesController(DataDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        //get post put deleter

        [HttpGet]
        public async Task<ActionResult<List<devices>>> GetDevies()
        {
            var devices = await _dbContext.devices.ToListAsync();
            if (devices.Count == 0)
            {
                return NotFound();
            }
            return Ok(devices);
        }
        //get by id
        [HttpGet("id")]
        public async Task<ActionResult<devices>> GetDevice(int id)
        {
            var devices = await _dbContext.devices.FindAsync(id);
            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }
        //Post
        [HttpPost]
        public async Task<ActionResult<devices>> PostDevice(devices device)
        {
            _dbContext.devices.Add(device);
            await _dbContext.SaveChangesAsync();

            return Ok(device);
        }
        //put
        [HttpPut]
        public async Task<ActionResult<devices>> PutDevice(int id, devices Newdevice)
        {
            var devices = await _dbContext.devices.FindAsync(id);

            if (devices == null)
            {
                return NotFound();
            }
            devices.id = Newdevice.id;
            devices.Title = Newdevice.Title;
            devices.Processor = Newdevice.Processor;
            devices.Price = Newdevice.Price;
            devices.Manufacturer_id = Newdevice.Manufacturer_id;

            await _dbContext.SaveChangesAsync();

            return Ok(devices);
        }
        //delete
        [HttpDelete]
        public async Task<ActionResult<devices>> deleteManufacturer(int id)
        {
            var device = await _dbContext.devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            _dbContext.devices.Remove(device);

            await _dbContext.SaveChangesAsync();

            return Ok(device);
        }
        //get by Manufacturer_id
        [HttpGet("Manufacturer_id")]
        public async Task<ActionResult<List<devices>>> GetDevices(int id)
        {
            var devices = await _dbContext.devices.Where(e=> e.Manufacturer_id == id ).ToListAsync();
            if (devices == null)
            {
                return NotFound();
            }
            return Ok(devices);
        }
    }
}
