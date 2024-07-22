using CobroSmart.Domain.Exceptions;
using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Context;
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
        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Company> Save(Company model)
        {
            if (model == null)
                throw new NotFoundException(nameof(model));

            var company = await _context.Companies.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<bool> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Company model)
        {
            throw new NotImplementedException();
        }
    }
}
