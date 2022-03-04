using VogCodeChallenge.API.Repositories.Interfaces;

namespace VogCodeChallenge.API.UnitOfWork.Interfaces
{
    public interface IUoW
    {
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }
        public int Complete();
    }
}
