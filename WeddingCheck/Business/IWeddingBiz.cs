using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCheck.Models;

namespace WeddingCheck.Business
{
    public interface IWeddingBiz
    {
        Task<List<Wedding>> GetInfo();

        Task<List<Wedding>> GetSingle(string name);

        void UpdateWeddingData(Wedding wedding);

        Task<WeddingCountViewModel> GetWeddingCount();

        Task<Dictionary<string, int>> GetWeddingCountByseat();
        Task<Dictionary<string, int>> GetWeddingCountCheckByseat();
    }
}
