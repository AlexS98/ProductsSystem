using System.Threading.Tasks;

namespace ProductSystem.Gateway.Services.Interfaces
{
    public interface IPingService
    {
        Task<string> PingDockerServiceAsync(string serviceName, int port);
    }
}