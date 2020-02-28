using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAPI.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<T> GetAllAsync<T>();
    }
}
