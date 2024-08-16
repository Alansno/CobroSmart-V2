using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
using CobroSmart.Infrastructure.Custom.Results;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Infrastructure.Repository
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly CobroSmartContext _context;
        public CompanyRepository(CobroSmartContext context)
        {
            _context = context;
        }
        public Task<Result<bool>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Company>> FindById(int Id)
        {
            var company = await _context.Companies.FindAsync(Id);
            if (company == null)
                return Result<Company>.Failure("Company not found");

            return Result<Company>.Success(company);
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies;
        }

        public async Task<Result<Company>> Save(Company model)
        {
            if (model == null)
                return Result<Company>.Failure("Model was found");

            await _context.Companies.AddAsync(model);
            await _context.SaveChangesAsync();
            return Result<Company>.Success(model);
        }

        public Task<Result<bool>> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(Company model)
        {
            throw new NotImplementedException();
        }
    }
}
