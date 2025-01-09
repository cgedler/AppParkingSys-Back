using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.App
{
    public class PriceService : IPriceService
    {
        Task<Price> IPriceService.DeletePrice(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Price>> IPriceService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Price?> IPriceService.GetPriceById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Price> IPriceService.RegisterPrice(Price price)
        {
            throw new NotImplementedException();
        }

        Task<Price> IPriceService.UpdatePrice(int id, Price price)
        {
            throw new NotImplementedException();
        }
    }
}
