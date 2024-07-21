using AutoMapper;
using Business.Constants;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Data.DiamondModels;
using Data.DiavanModels;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DiamondService
    {
        private readonly SWP391_DiamondSystemContext _diamondContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiamondService(SWP391_DiamondSystemContext diamondContext, UnitOfWork unitOfWork, IMapper mapper)
        {
            _diamondContext = diamondContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                var diamondList = _unitOfWork.DiamondRepository.GetAll();
                var rs = _mapper.Map<List<DiamondModel>>(diamondList);
                return new ServiceResult(200, "Get All Diamonds", rs);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> MigrateToSystemDbByDate()
        {
            try
            {
                var diamondList = await _diamondContext.Set<Diamond>().Where(_ => _.UpdateDate.Value.Day == DateTime.Now.Day).ToListAsync();
                var map = _mapper.Map<List<SystemDiamond>>(diamondList);
                await _unitOfWork.DiamondRepository.CreateRangeAsync(map);
                return new ServiceResult(200, "Create success");
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> CalculateDiamondPrice(DiamondCalculateReq req)
        {
            try
            {
                var nullFields = new List<string>();

                if (req == null
                    || req.Origin == null
                    || req.Shape == null
                    || req.Carat == null
                    || req.Color == null
                    || req.Clarity == null
                    || req.Fluorescence == null
                    || req.Symmetry == null
                    || req.Polish == null
                    || req.CutGrade == null)
                {
                    return new ServiceResult(400, "Null field in request");
                }

                var diamondList = await _unitOfWork.DiamondRepository.GetDiamondByParameters(req.Origin, req.Shape, req.Carat, req.Color, req.Clarity, req.Fluorescence, req.Symmetry, req.Polish, req.CutGrade);

                var minPrice = diamondList.Min(d => d.Value);
                var maxPrice = diamondList.Max(d => d.Value);

                var totalPrice = diamondList.Sum(d => d.Value);
                var fairPrice = totalPrice / diamondList.Count;

                var thirtyDaysAgo = DateTime.Today.AddDays(-30);

                var oldestDiamond = diamondList.OrderBy(d => d.UpdateDate).First();
                var newestDiamond = diamondList.OrderByDescending(d => d.Value).First();

                var percentChange = 100 - (newestDiamond.Value / oldestDiamond.Value * 100);

                var pricePerCarat = fairPrice / req.Carat;

                var rs = new DiamondCalculateResponse
                {
                    Origin = req.Origin,
                    Carat = req.Carat,
                    Clarity = req.Clarity,
                    Color = req.Color,
                    Shape = req.Shape,
                    MinPrice = (double)Math.Round((decimal)minPrice * 10) / 10,
                    MaxPrice = (double)Math.Round((decimal)maxPrice * 10) / 10,
                    FairPrice = (double)Math.Round((decimal)fairPrice * 10) / 10,
                    Last30DayChange = (double)Math.Round((decimal)percentChange * 10) / 10,
                    PricePerCarat = (double)Math.Round((decimal)pricePerCarat * 10) / 10
                };

                return new ServiceResult(200, "Calculated successfully", rs);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
