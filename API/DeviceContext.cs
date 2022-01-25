using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API
{
    /// <summary>
    /// Defines the application context
    /// </summary>
    public class DeviceContext : DbContext
    {

        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {

        }
        /// <summary>
        /// The devices
        /// </summary>
        public DbSet<Device> Devices { get; set; }

        /// <summary>
        /// The device values
        /// </summary>
        public DbSet<DeviceValue> DeviceValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var device1Id = Guid.NewGuid();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Device>().HasMany<DeviceValue>(g => g.ValueList);

            modelBuilder.Entity<Device>().HasData(new Device
            {
                DeviceId = device1Id,
                Name = "Device1",

            });

            modelBuilder.Entity<DeviceValue>().HasData(new List<DeviceValue>()
            {
                new DeviceValue()
                {
                    ValueId = Guid.NewGuid(),
                    DeviceId = device1Id,
                    CreationDate = DateTime.Now,
                    Value = "1"
                },
                new DeviceValue()
                {
                    ValueId = Guid.NewGuid(),
                    DeviceId = device1Id,
                    CreationDate = DateTime.Now,
                    Value = "2"
                },
                new DeviceValue()
                {
                    ValueId = Guid.NewGuid(),
                    DeviceId = device1Id,
                    CreationDate = DateTime.Now,
                    Value = "3"
                }
            });
        }
    }
}
