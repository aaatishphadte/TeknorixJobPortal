using TeknorixAPI.Models;

namespace TeknorixAPI.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department?> GetSingleDepartment(int id);
        Task<List<Department>> AddDepartment(Department Department);
        Task<List<Department>?> UpdateDepartment(int id, Department request);
        Task<List<Department>?> DeleteDepartment(int id);
    }
}
