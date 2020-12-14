using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductSystem.Gateway.Services.Interfaces
{
    public interface IRequestService
    {
        Task<string> PingDockerServiceAsync(string serviceName, int port);
        Task<string> GetFromDockerServiceAsync(string serviceName, int port, string path);
        Task<string> GetFromDockerServiceAsync(string serviceName, int port, string path, string token);
        Task<string> GetFromDockerServiceAsync(string serviceName, int port, string path, Dictionary<string, string> data);
        Task<string> PostFromDockerServiceAsync<T>(string serviceName, int port, string path, T data);
    }
}