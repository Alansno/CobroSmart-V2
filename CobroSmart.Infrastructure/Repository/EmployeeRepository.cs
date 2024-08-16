using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Custom.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Infrastructure.Repository
{
    public class EmployeeRepository : IRepository<Employees>
    {
        private readonly CobroSmartContext _context;
        public EmployeeRepository(CobroSmartContext context)
        {
            _context = context;
        }
        public Task<Result<bool>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Employees>> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employees> GetAll()
        {
            return _context.Employees;
        }

        public async Task<Result<Employees>> Save(Employees model)
        {
            if (model == null)
                return Result<Employees>.Failure("Model was found");

            await _context.Employees.AddAsync(model);
            await _context.SaveChangesAsync();
            return Result<Employees>.Success(model);
        }

        public Task<Result<bool>> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(Employees model)
        {
            throw new NotImplementedException();
        }
    }
}
