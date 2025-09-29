using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities; 

namespace Application.Repositories
{
    public interface IAutomovilRepository
    {
        Task AddAsync(Automovil automovil);
        Task <Automovil> GetByIdAsync(int Id);
        Task <IEnumerable<Automovil>> GetAllAsync();
        Task UpdateAsync(Automovil automovil);
        Task DeleteAsync(int Id);
        Task <Automovil> GetByChasisAsync (string NumeroChasis);

    }
}
