using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API.Repositories.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public void AddEmployeeToDepartment(int id, Employee employee);
    }
}
