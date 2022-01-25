using API.Models;
using API.Services;
using System.Collections.Generic;

namespace API
{
    public class DeviceService : IDeviceService
    {

        private readonly DeviceContext _context;

        public DeviceService(DeviceContext context)
        {
            this._context = context;
        }

        public async Task AddDeviceValue(Guid deviceId, string value)
        {
            var deviceValue = new DeviceValue()
            {
                ValueId = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                DeviceId = deviceId,
                Value = value
            };

            await _context.DeviceValues.AddAsync(deviceValue);
            await _context.SaveChangesAsync();
        }

        public async Task CreateDevice(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public Device? GetDeviceAsync(Guid deviceId)
        {
            return _context.Devices.FirstOrDefault(x => x.DeviceId == deviceId);
        }

        public Task<List<Device>> ListDevices()
        {
            var list = _context.Devices.Select(x => new Device()
            {
                DeviceId = x.DeviceId,
                Name = x.Name,
                ValueList = _context.DeviceValues.Where(y => y.DeviceId == x.DeviceId).ToList()
            }).ToList();

            return Task.FromResult(list);
            //var device1Id = Guid.NewGuid();
            //var device2Id = Guid.NewGuid();
            //var list = new List<Device>()
            //{
            //    new Device()
            //    {
            //        DeviceId = device1Id,
            //        Name = "Device1",
            //        ValueList = new List<DeviceValue>()
            //        {
            //            new DeviceValue()
            //            {
            //                DeviceId = device1Id,
            //                CreationDate = DateTime.Now,
            //                Value = "1"
            //            },
            //            new DeviceValue()
            //            {
            //                DeviceId = device1Id,
            //                CreationDate = DateTime.Now,
            //                Value = "2"
            //            },
            //            new DeviceValue()
            //            {
            //                DeviceId = device1Id,
            //                CreationDate = DateTime.Now,
            //                Value = "3"
            //            }
            //        }
            //    },
            //    new Device()
            //    {
            //        DeviceId = device2Id,
            //        Name = "Device",
            //        ValueList = new List<DeviceValue>()
            //        {
            //            new DeviceValue()
            //            {
            //                DeviceId = device2Id,
            //                CreationDate = DateTime.Now,
            //                Value = "4"
            //            },
            //            new DeviceValue()
            //            {
            //                DeviceId = device2Id,
            //                CreationDate = DateTime.Now,
            //                Value = "5"
            //            },
            //            new DeviceValue()
            //            {
            //                DeviceId = device2Id,
            //                CreationDate = DateTime.Now,
            //                Value = "6"
            //            }
            //        }
            //    },

            //};
            //return Task.FromResult(list);
        }

        public IEnumerable<DeviceValue> GetDeviceValuesAsync(Guid deviceId)
        {
            return _context.DeviceValues.Where(x => x.DeviceId == deviceId);
        }
    }
}
