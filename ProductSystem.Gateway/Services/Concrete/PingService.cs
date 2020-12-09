using System;
using System.Net.Http;
using System.Threading.Tasks;
using ProductSystem.Gateway.Services.Interfaces;

namespace ProductSystem.Gateway.Services.Concrete
{
    public class PingService : IPingService
    {
        private readonly HttpClient _client;

        public PingService()
        {
            _client = new HttpClient();
        }

        public async Task<string> PingDockerServiceAsync(string serviceName, int port)
        {
            try
            {
                var authServiceResponse = await _client.GetAsync($"http://{serviceName}:{port}/ping");
                var authServiceMessage = authServiceResponse.IsSuccessStatusCode
                    ? $"Service \"{serviceName}\" is ok! Message: {authServiceResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult()}"
                    : $"Service \"{serviceName}\" check fails! Code: {authServiceResponse.StatusCode}. Path: http://{serviceName}:{port}/ping";
                return authServiceMessage;
            }
            catch (Exception ex)
            {
                return $"Unhandled exception: {ex.GetType().Name}, message: {ex.Message}";
            }
        }
    }
}