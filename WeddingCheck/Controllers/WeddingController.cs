using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeddingCheck.Business;
using WeddingCheck.Models;
using WeddingCheck.Repositories;

namespace WeddingCheck.Controllers
{
    public class WeddingController : Controller
    {
        

        private readonly IWeddingBiz _biz;
        private readonly IWeddingRepository _weddingRepository;

        public WeddingController(IWeddingBiz biz, IWeddingRepository weddingRepository)
        {
            _biz = biz;
            _weddingRepository = weddingRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var info = await _biz.GetInfo();
            return View(Mapper.Map<List<WeddingViewModel>>(info));
        }

        [HttpPost]
        public async Task<IActionResult> Submit(string name)
        {
            var info = await _biz.GetSingle(name);
            return Ok(Mapper.Map<List<WeddingViewModel>>(info));
        }

        [HttpPost]
        public IActionResult Check(Wedding wedding,int num)
        {
            try
            {
                if(num.Equals(1))
                {
                    wedding.Accompanied = 1;//只來一人
                }
                _biz.UpdateWeddingData(wedding);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<IActionResult> Statistics()
        {
            var result = await _biz.GetWeddingCount();
            int percent = (100 * result.Actual) / result.Total;
            ViewBag.Attendancerate = (100 * result.Actual) / result.Total;
            return View(result);
        }

        public async Task<IActionResult> StatisticsByseat()
        {
            var seat = await _biz.GetWeddingCountByseat();
            var seatCheck = await _biz.GetWeddingCountCheckByseat();
            ViewBag.seat = seat;
            ViewBag.seatCheck = seatCheck;
            return View();
        }

        //public IActionResult Get(string id)
        //{
        //    try
        //    {
        //        Wedding myModel = _weddingRepository.GetSingle(id);

        //        if (myModel == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(Mapper.Map<WeddingViewModel>(myModel));
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //public IActionResult Post([FromBody]WeddingViewModel viewModel)
        //{
        //    try
        //    {
        //        if (viewModel == null)
        //        {
        //            return BadRequest();
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        Wedding item = Mapper.Map<Wedding>(viewModel);

        //        _weddingRepository.Add(item);
        //        int save = _weddingRepository.Save();

        //        if (save > 0)
        //        {
        //            return CreatedAtRoute("GetSingle", new { controller = "MyModel", id = item.Phone }, item);
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //public IActionResult Put(string id, [FromBody]WeddingViewModel viewModel)
        //{
        //    try
        //    {
        //        if (viewModel == null)
        //        {
        //            return BadRequest();
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        Wedding singleById = _weddingRepository.GetSingle(id);

        //        if (singleById == null)
        //        {
        //            return NotFound();
        //        }

        //        singleById.Name = viewModel.Name;

        //        _weddingRepository.Update(singleById);
        //        int save = _weddingRepository.Save();

        //        if (save > 0)
        //        {
        //            return Ok(Mapper.Map<WeddingViewModel>(singleById));
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        //public IActionResult Delete(string id)
        //{
        //    try
        //    {
        //        Wedding singleById = _weddingRepository.GetSingle(id);

        //        if (singleById == null)
        //        {
        //            return NotFound();
        //        }

        //        _weddingRepository.Delete(singleById);
        //        int save = _weddingRepository.Save();

        //        if (save > 0)
        //        {
        //            return NoContent();
        //        }

        //        return BadRequest();
        //    }
        //    catch (Exception exception)
        //    {
        //        //Do something with the exception
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}
    }
}
