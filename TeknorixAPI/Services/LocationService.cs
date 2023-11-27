using Microsoft.EntityFrameworkCore;
using TeknorixAPI.Data;
using TeknorixAPI.Models;

namespace TeknorixAPI.Services
{
    public class LocationService: ILocationService
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> AddLocation(Location Location)
        {
            _context.Locations.Add(Location);
            await _context.SaveChangesAsync();
            return await _context.Locations.ToListAsync();
        }

        public async Task<List<Location>?> DeleteLocation(int id)
        {
            var Location = await _context.Locations.FindAsync(id);
            if (Location is null)
                return null;

            _context.Locations.Remove(Location);
            await _context.SaveChangesAsync();

            return await _context.Locations.ToListAsync();
        }

        public async Task<List<Location>> GetAllLocations()
        {
            var Locations = await _context.Locations.ToListAsync();
            return Locations;
        }

        public async Task<Location?> GetSingleLocation(int id)
        {
            var Location = await _context.Locations.FindAsync(id);
            if (Location is null)
                return null;

            return Location;
        }

        public async Task<List<Location>?> UpdateLocation(int id, Location request)
        {
            var Location = await _context.Locations.FindAsync(id);
            if (Location is null)
                return null;

            //Location.FirstName = request.FirstName;
            //Location.LastName = request.LastName;
            //Location.DOB = request.DOB;


            await _context.SaveChangesAsync();

            return await _context.Locations.ToListAsync();
        }
    }
}
