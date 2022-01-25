namespace API.Models
{
    /// <summary>
    /// Defines a device
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Id of the device
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// Name of the device
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List the device values
        /// </summary>
        public List<DeviceValue> ValueList { get; set; }

    }
}
