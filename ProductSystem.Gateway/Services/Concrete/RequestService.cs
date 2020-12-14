using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using ProductSystem.Gateway.Services.Interfaces;

namespace ProductSystem.Gateway.Services.Concrete
{
    public class RequestService : IRequestService
    {
        public const string authservice = "authservice";
        public const int authservicePort = 5001;
        public const string managservice = "managservice";
        public const int managservicePort = 5003;

        private readonly HttpClient _client;

        public RequestService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetFromDockerServiceAsync(string serviceName, int port, string path)
        {
            try
            {
                var serviceResponse = await _client.GetAsync($"http://{serviceName}:{port}{path}");
                var serviceMessage = serviceResponse.IsSuccessStatusCode
                    ? await serviceResponse.Content.ReadAsStringAsync()
                    : $"Some error occured, reason: {ReasonPhrases.GetReasonPhrase((int)serviceResponse.StatusCode)}";
                return serviceMessage;
            }
            catch (Exception ex)
            {
                return $"Unhandled exception: {ex.GetType().Name}, message: {ex.Message}";
            }
        }

        public async Task<string> GetFromDockerServiceAsync(string serviceName, int port, string path, Dictionary<string, string> data)
        {
            try
            {
                var requestParams = string.Join('&', data.Select(cur => $"{cur.Key}={cur.Value}"));
                var requestPath = new StringBuilder($"http://{serviceName}:{port}{path}");
                if (!string.IsNullOrEmpty(requestParams))
                {
                    requestPath.Append("?").Append(requestParams);
                }

                var serviceResponse = await _client.GetAsync(requestPath.ToString());
                var serviceMessage = serviceResponse.IsSuccessStatusCode
                    ? await serviceResponse.Content.ReadAsStringAsync()
                    : $"Some error occured, reason: {ReasonPhrases.GetReasonPhrase((int)serviceResponse.StatusCode)}";
                return serviceMessage;
            }
            catch (Exception ex)
            {
                return $"Unhandled exception: {ex.GetType().Name}, message: {ex.Message}";
            }
        }

        public async Task<string> GetFromDockerServiceAsync(string serviceName, int port, string path, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await GetFromDockerServiceAsync(serviceName, port, path);
            _client.DefaultRequestHeaders.Clear();
            return response;
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

        public async Task<string> PostFromDockerServiceAsync<T>(string serviceName, int port, string path, T data)
        {
            try
            {
                var serializedData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var serviceResponse = await _client.PostAsync($"http://{serviceName}:{port}{path}", serializedData);
                var serviceMessage = serviceResponse.IsSuccessStatusCode
                    ? await serviceResponse.Content.ReadAsStringAsync()
                    : $"Some error occured, reason: {ReasonPhrases.GetReasonPhrase((int)serviceResponse.StatusCode)}";
                return serviceMessage;
            }
            catch (Exception ex)
            {
                return $"Unhandled exception: {ex.GetType().Name}, message: {ex.Message}";
            }
        }
    }
}