using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.API.Context;
using VogCodeChallenge.API.Models;
using VogCodeChallenge.API.Repositories.Interfaces;

namespace VogCodeChallenge.API.Repositories
{
    public class DepartmentRepository : IDepartmentRepository, IGenericRepository<Department>
    {
        private VogDbContext _context;

        public DepartmentRepository(VogDbContext context)
        {
            _context = context;
        }

        public int Add(Department entityObj)
        {
            var entry = _context.Departments.Add(entityObj);
            entry.State = EntityState.Detached;
            _context.SaveChanges();

            return entityObj.ID;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.Select(department => department).Include(department => department.Employees);
        }

        public IList<Department> ListAll()
        {
            return _context.Departments.Select(department => department).Include(department => department.Employees).ToList();
        }

        public void AddEmployeeToDepartment(int id, Employee employee)
        {
            Department department = _context.Departments.First<Department>(department => department.ID == id);
            department.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Where(department => department.ID == id).Include(department => department.Employees).FirstOrDefault();
        }
    }
}
