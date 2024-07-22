using CobroSmart.Domain.Models;
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
        Task<M> Save(M model);
        Task<bool> Update(M model);
        Task<bool> Delete(int Id);
        Task<bool> SoftDelete(int Id);
        Task<M> FindById(int Id);
        Task<IQueryable<M>> GetAll();
    }
}
