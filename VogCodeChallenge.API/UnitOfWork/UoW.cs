using VogCodeChallenge.API.Context;
using VogCodeChallenge.API.Repositories.Interfaces;
using VogCodeChallenge.API.UnitOfWork.Interfaces;

namespace VogCodeChallenge.API.UnitOfWork
{
    public class UoW : IUoW
    {
        private readonly VogDbContext _context;
        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }


        public UoW(VogDbContext context, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _context = context;
            Employees = employeeRepository;
            Departments = departmentRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
