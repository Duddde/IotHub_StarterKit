using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet("/GetDevices")]
        public async Task<List<Device>> Get()
        {
            return await _deviceService.ListDevices();
        }

        [HttpPost("/CreateDevice")]
        public Task<ObjectResult> CreateDevice([FromBody] Device device)
        {
            try
            {
                _deviceService.CreateDevice(device);
            }
            catch (Exception ex)
            {
                return Task.FromResult(Problem(ex.Message));
            }
            return Task.FromResult(new ObjectResult(null){StatusCode = 200});
        }

        [HttpPost("/DeviceValue")]
        public IActionResult AddDeviceValue([FromBody] DeviceValue value)
        {
            try
            {
                _deviceService.AddDeviceValue(value.DeviceId, value.Value);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            return Ok();
        }
    }
}