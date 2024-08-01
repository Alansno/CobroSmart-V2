using CobroSmart.Domain.Models;
using CobroSmart.Infrastructure.Custom.Results;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Infrastructure.Repository
{
    public interface IRepository<M> where M : class
    {
        Task<Result<M>> Save(M model);
        Task<Result<bool>> Update(M model);
        Task<Result<bool>> Delete(int Id);
        Task<Result<bool>> SoftDelete(int Id);
        Task<Result<M>> FindById(int Id);
        IQueryable<M> GetAll();
    }
}
