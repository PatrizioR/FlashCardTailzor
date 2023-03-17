using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardTailzor.Data.Models.Repositories
{
    public class MockClientRepository : IClientRepository
    {
        public Task<IEnumerable<T>> GetAllAsync<T>(HttpClient client)
        {
            throw new NotImplementedException();
        }
    }
}
