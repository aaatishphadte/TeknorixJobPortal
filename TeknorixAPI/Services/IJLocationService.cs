using TeknorixAPI.Models;

namespace TeknorixAPI.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllLocations();
        Task<Location?> GetSingleLocation(int id);
        Task<List<Location>> AddLocation(Location Location);
        Task<List<Location>?> UpdateLocation(int id, Location request);
        Task<List<Location>?> DeleteLocation(int id);
    }
}
