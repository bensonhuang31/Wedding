using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCheck.Models;

namespace WeddingCheck.Repositories
{
    public class WeddingRepository : IWeddingRepository
    {
        private TSContext _db;

        public WeddingRepository(TSContext db)
        {
            _db = db;
        }

        public async Task<List<Wedding>> GetAll()
        {
            var result = from dc in _db.Wedding
                         orderby dc.Seat ascending
                         select dc;

            return await result.ToListAsync();
        }

        public async Task<List<Wedding>> GetSingle(string name)
        {
            var result = from dc in _db.Wedding
                         where dc.Name.Contains(name)
                         select dc;

            return await result.ToListAsync();
        }

        public void updateWeddingData(Wedding wedding)
        {
            var result = _db.Wedding.SingleOrDefault(m => m.SN == wedding.SN);

            if (result != null)
            {
                result.Checkin = wedding.Accompanied;
                result.UpdateTime = DateTime.Now;
                _db.SaveChanges();
            }
        }

        public async Task<IEnumerable<int>> GetSeatAsync()
        {
            var result = await _db.Wedding.GroupBy(m => m.Seat).Select(y => y.FirstOrDefault()).ToListAsync();
            var seat = from dc in result
                       orderby dc.Seat ascending
                       select dc.Seat;

            return seat;
        }



        public Wedding Add(Wedding toAdd)
        {
            _db.Wedding.Add(toAdd);
            return toAdd;
        }

        public Wedding Update(Wedding toUpdate)
        {
            _db.Wedding.Update(toUpdate);
            return toUpdate;
        }

        public void Delete(Wedding toDelete)
        {
            _db.Wedding.Remove(toDelete);
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
