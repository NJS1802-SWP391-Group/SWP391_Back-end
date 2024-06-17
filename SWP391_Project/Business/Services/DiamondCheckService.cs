using AutoMapper;
using Business.Constants;
using Common.Responses;
using Data.Repositories;
using Data.Repositories.DiamondRepo;
using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DiamondCheckService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public DiamondCheckService(UnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IServiceResult> GetInfomationByCertificateId(string id)
        {
            
            try
            {
                var diamond =await _unitOfWork.DiamondCheckRepository.GetDiamondsByIdCertificate(id);
                var result = _mapper.Map<DimondCheckInformation>(diamond);
                var fairPrice = 0;
                result.FairPrice = fairPrice;
                return new ServiceResult(200, "Diamond Check", result); 
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message, null);
            }
        }
    }
}
