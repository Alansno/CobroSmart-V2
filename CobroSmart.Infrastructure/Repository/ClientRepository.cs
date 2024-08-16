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
    public class ClientRepository : IRepository<Client>
    {
        private readonly CobroSmartContext _context;
        public ClientRepository(CobroSmartContext context)
        {
            _context = context;
        }
        public Task<Result<bool>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Client>> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Client>> Save(Client model)
        {
            if (model == null)
                return Result<Client>.Failure("Model was found");

            await _context.clients.AddAsync(model);
            await _context.SaveChangesAsync();
            return Result<Client>.Success(model);
        }

        public Task<Result<bool>> SoftDelete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> Update(Client model)
        {
            throw new NotImplementedException();
        }
    }
}
