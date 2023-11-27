using Microsoft.EntityFrameworkCore;
using TeknorixAPI.Data;
using TeknorixAPI.Models;

namespace TeknorixAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> AddDepartment(Department Department)
        {
            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();
            return await _context.Departments.ToListAsync();
        }

        public async Task<List<Department>?> DeleteDepartment(int id)
        {
            var Department = await _context.Departments.FindAsync(id);
            if (Department is null)
                return null;

            _context.Departments.Remove(Department);
            await _context.SaveChangesAsync();

            return await _context.Departments.ToListAsync();
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            var Departments = await _context.Departments.ToListAsync();
            return Departments;
        }

        public async Task<Department?> GetSingleDepartment(int id)
        {
            var Department = await _context.Departments.FindAsync(id);
            if (Department is null)
                return null;

            return Department;
        }

        public async Task<List<Department>?> UpdateDepartment(int id, Department request)
        {
            var Department = await _context.Departments.FindAsync(id);
            if (Department is null)
                return null;

            //Department.FirstName = request.FirstName;
            //Department.LastName = request.LastName;
            //Department.DOB = request.DOB;


            await _context.SaveChangesAsync();

            return await _context.Departments.ToListAsync();
        }
    }
}
