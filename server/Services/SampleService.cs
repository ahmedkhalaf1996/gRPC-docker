using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using server.Protos;

namespace server.Services
{
    public class SampleService : Sample.SampleBase
    {
        private readonly ILogger<SampleService> logger;

        public SampleService(ILogger<SampleService> logger)
        {
            this.logger = logger;
         }

        public override Task<SampleResponse> GetData(SampleRequest request, ServerCallContext context)
        {
            // Process request and return response
             logger.LogInformation($"New Message: DeviceId: {request.Id}");
            var response = new SampleResponse { Message = "Hello from App1!" };
            return Task.FromResult(response);
        }
    }
}