using AutoMapper;
using Business.Constants;
using Common.Responses;
using Data.Repositories;
using Data.Repositories.DiamondRepo;
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
                if (diamond == null) { throw new Exception("Not Found"); }
                var result = _mapper.Map<DimondCheckInformation>(diamond);
                double fairPrice = 0;
                result.MinPrice = diamond.DiamondCheckValues.Min(x => x.Price);
                result.MaxPrice = diamond.DiamondCheckValues.Max(x => x.Price);
                fairPrice = diamond.DiamondCheckValues.Sum(x=>x.Price) / (diamond.DiamondCheckValues.Count());
                result.FairPrice = fairPrice;
                result.SetLinkImageShape();
                result.UpdateDay = diamond.DiamondCheckValues.Max(item => item.UpdateDay);
                var Ratio = (diamond.DiamondCheckValues.OrderByDescending(x => x.UpdateDay).FirstOrDefault().Price-diamond.DiamondCheckValues.OrderBy(x => x.UpdateDay).FirstOrDefault().Price) / diamond.DiamondCheckValues.OrderBy(x => x.UpdateDay).FirstOrDefault().Price;
                result.Ratio = Math.Round(Ratio * 100, 2);
                return new ServiceResult(200, "Diamond Check", result); 
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message, null);
            }
        }
    }
}
