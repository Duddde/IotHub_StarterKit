using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventHubs;
using System.Text;
using System.Net.Http;
using API.Services;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public class Function
    {
        private static IDeviceService _deviceService;

        public Function(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }


        [FunctionName("Function")]
        public void Run([IoTHubTrigger("messages/events", Connection = "ConnectionString")]EventData message, ILogger log)
        {
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}