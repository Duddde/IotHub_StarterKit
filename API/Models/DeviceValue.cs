using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    /// <summary>
    /// Defines a device value
    /// </summary>
    public class DeviceValue
    {
        [Key]
        public Guid ValueId { get; set; }

        /// <summary>
        /// The device id
        /// </summary>
        public Guid DeviceId { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The creation date
        /// </summary>
        public DateTime CreationDate { get; set; }
        
    }
}
