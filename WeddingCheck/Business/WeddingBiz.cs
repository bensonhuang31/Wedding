using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingCheck.Models;
using WeddingCheck.Repositories;
using WeddingCheck.Service;

namespace WeddingCheck.Business
{
    public class WeddingBiz : IWeddingBiz
    {
        private readonly IWeddingRepository _weddingRepository;
        private readonly SystemOptionsConfig _systemConfig;

        public WeddingBiz(IWeddingRepository reportRepository, IOptions<SystemOptionsConfig> systemConfig)
        {
            _weddingRepository = reportRepository;
            _systemConfig = systemConfig.Value;
        }


        public async Task<List<Wedding>> GetInfo()
        {
            var wedding = await _weddingRepository.GetAll();

            return wedding;
        }

        public async Task<List<Wedding>> GetSingle(string name)
        {
            var wedding = await _weddingRepository.GetSingle(name);

            return wedding;
        }

        public void UpdateWeddingData(Wedding wedding)
        {
            _weddingRepository.updateWeddingData(wedding);
        }   

        public async Task<WeddingCountViewModel> GetWeddingCount()
        {
            var result = await _weddingRepository.GetAll();

            var weddingCountViewModel = new WeddingCountViewModel
            {
                Total = result.Sum(c => c.Accompanied),
                Actual = result.Where(c => c.Checkin != 0).Sum(c => c.Checkin),
                Absentee = result.Sum(c => c.Accompanied) - result.Where(c => c.Checkin != 0).Sum(c => c.Checkin),
            };

            return weddingCountViewModel;
        }

        public async Task<Dictionary<string,int>> GetWeddingCountByseat()
        {
            Dictionary<string, int> seatCount = new Dictionary<string, int>();
            var result = await _weddingRepository.GetAll();
            var seat = await _weddingRepository.GetSeatAsync();
            var seatList = seat.ToList();
            for (var i = 0; i< seatList.Count();i++)
            {
                int count = result.Where(c => c.Seat.Equals(seatList[i])).Sum(c => c.Accompanied);
                seatCount.Add(seatList[i].ToString(), count);
            }

            return seatCount;
        }

        public async Task<Dictionary<string, int>> GetWeddingCountCheckByseat()
        {
            Dictionary<string, int> seatCountCheck = new Dictionary<string, int>();
            var result = await _weddingRepository.GetAll();
            var seat = await _weddingRepository.GetSeatAsync();
            var seatList = seat.ToList();
            for (var i = 0; i < seatList.Count(); i++)
            {
                int count = result.Where(c => c.Seat.Equals(seatList[i])).Sum(c => c.Checkin);
                seatCountCheck.Add(seatList[i].ToString(), count);
            }

            return seatCountCheck;
        }
    }
}
