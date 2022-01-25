using API.Models;
using Refit;

namespace API.Services
{
    public interface IDeviceService
    {
        [Get("/GetDevices")]
        public  Task<List<Device>> ListDevices();

        public IEnumerable<DeviceValue> GetDeviceValuesAsync(Guid deviceId);

        public Device? GetDeviceAsync(Guid deviceId);

        [Post("/CreateDevice")]
        public Task CreateDevice(Device device);

        [Post("/DeviceValue")]
        public Task AddDeviceValue(Guid deviceId, string value);
    }
}
