using AutoMapper;
using Business.Constants;
using Common.Enums;
using Common.Responses;
using Data.Repositories;
using Domain.DiamondEntities;
using Domain.DiavanEntities;
using Microsoft.EntityFrameworkCore;
using SWP391_Project.Data.Databases.DiamondSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DiamondService
    {
        private readonly DiamondContext _diamondContext;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiamondService(DiamondContext diamondContext, UnitOfWork unitOfWork, IMapper mapper)
        {
            _diamondContext = diamondContext;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<IServiceResult> CalculateDiamondPrice()
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
    }
}
