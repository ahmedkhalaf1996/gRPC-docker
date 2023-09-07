using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using client.Protos;
namespace client.Services
{
    public class SampleServiceClient
    {
        private readonly GrpcChannel _channel;
        private readonly Sample.SampleClient _client;

        public SampleServiceClient()
        {
            _channel = GrpcChannel.ForAddress("http://server:80");
            _client = new Sample.SampleClient(_channel);
        }

        public async Task<string> GetApp1Data()
        {
            var request = new SampleRequest{
                Id = "hello Ahmed 8-089-089-8-809"
            };
            var response = await _client.GetDataAsync(request);
            return response.Message;
        }
    }
}