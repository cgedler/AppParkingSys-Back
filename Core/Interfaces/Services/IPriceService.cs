using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPriceService
    {
        Task<Price?> GetPriceById(int id);
        Task<IEnumerable<Price>> GetAll();
        Task<Price> RegisterPrice(Price price);
        Task<Price> UpdatePrice(int id, Price price);
        Task<Price> DeletePrice(int id);
    }
}
