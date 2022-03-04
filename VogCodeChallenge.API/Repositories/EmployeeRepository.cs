using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.API.Context;
using VogCodeChallenge.API.Models;
using VogCodeChallenge.API.Repositories.Interfaces;

namespace VogCodeChallenge.API.Repositories
{
    public class EmployeeRepository : IGenericRepository<Employee>, IEmployeeRepository
    {
        private VogDbContext _context;

        public EmployeeRepository(VogDbContext context)
        {
            this._context = context;
        }

        public int Add(Employee entityObj)
        {
            var entry = _context.Employees.Add(entityObj);
            entry.State = EntityState.Detached;

            _context.SaveChanges();

            return entityObj.ID;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Select(employee => employee);
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(employee => employee.ID == id);
        }

        public IList<Employee> ListAll()
        {
            var x = _context.Employees.Select(employee => employee);
            return _context.Employees.ToList();
        }
    }
}
