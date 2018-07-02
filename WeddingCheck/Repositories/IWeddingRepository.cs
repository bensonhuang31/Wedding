using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCheck.Models;

namespace WeddingCheck.Repositories
{
    public interface IWeddingRepository
    {
        Task<List<Wedding>> GetAll();
        Task<List<Wedding>> GetSingle(string name);
        Wedding Add(Wedding toAdd);
        Wedding Update(Wedding toUpdate);
        Task<IEnumerable<int>> GetSeatAsync();
        void Delete(Wedding toDelete);
        int Save();
        void updateWeddingData(Wedding wedding);
    }
}
