using AutoMapper;
using Business.Constants;
using Business.Services.Firebase;
using Common.DTOs;
using Common.Enums;
using Common.Requests;
using Common.Responses;
using Data.Helpers;
using Data.Repositories;
using Domain.DiavanEntities;
using SWP391_Project.Common.Requests;
using SWP391_Project.Domain.DiavanEntities;
using SWP391_Project.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IResultService
    {
        public Task<IServiceResult> GetAll();
        public Task<IServiceResult> GetAllActive();
        public Task<IServiceResult> GetById(int id);
        public Task<IServiceResult> GetByOrderDetailId(int id);
        public Task<IServiceResult> Create(CreateResultReq req);
        public Task<IServiceResult> Update(int id, UpdateResultReq req);
        public Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req);
    }
    public class ResultService : IResultService
    {
        private readonly IFirebaseService _firebaseService;
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResultService(UnitOfWork unitOfWork, IFirebaseService firebaseService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _firebaseService = firebaseService;
        }

        public async Task<IServiceResult> GetAll()
        {
            try
            {
                var results = await _unitOfWork.ResultRepository.GetAllAsync();
                var rs = _mapper.Map<List<ResultModel>>(results);
                return new ServiceResult(200, "Get all result", rs);
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetAllActive()
        {
            try
            {
                var results = await _unitOfWork.ResultRepository.GetAllActiveAsync();
                var rs = _mapper.Map<List<ResultModel>>(results);
                if (results.Any())
                {
                    return new ServiceResult(200, "Get all active result", rs);
                }
                else
                {
                    return new ServiceResult(404, "No active service details");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetById(int id)
        {
            try
            {
                var result = await _unitOfWork.ResultRepository.GetByIdAsync(id);
                var rs = _mapper.Map<GetResultByIdResponse>(result);
                var imageLists = await _unitOfWork.ResultImageRepository.GetByResultIdAsync(id);
                var rsImages = _mapper.Map<List<ResultImages>>(imageLists);
                rs.ResultImages = rsImages;
                if (result is null)
                {
                    return new ServiceResult(404, "Cannot find result");
                }
                else
                {
                    return new ServiceResult(200, "Get result by id", rs);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> GetByOrderDetailId(int id)
        {
            try
            {
                var result = await _unitOfWork.ResultRepository.GetByOrderDetailIdAsync(id);
                var rs = _mapper.Map<ResultModel>(result);
                var imageUrls = await _unitOfWork.ResultImageRepository.GetByResultIdAsync(result.ResultId);
                rs.ImageUrls = imageUrls.Select(_ => _.ImageUrl).ToList();
                if (result is null)
                {
                    return new ServiceResult(404, "Cannot find result");
                }
                else
                {
                    return new ServiceResult(200, "Get result by id", rs);
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> Create(CreateResultReq req)
        {
            try
            {
                var orDetail = _unitOfWork.OrderDetailRepository.GetAll().Where(_ => _.OrderDetailId == req.OrderDetailId && _.Status.Equals(ValuationDetailStatusEnum.Valuating.ToString())).FirstOrDefault();

                if (orDetail is null)
                {
                    return new ServiceResult(404, "Cannot find order detail");
                }

                if (orDetail.ResultId != null)
                {
                    return new ServiceResult(400, "Fail");
                }
                var createObj = _mapper.Map<Result>(req);
                createObj.Code = orDetail.Code;
                if (!createObj.IsDiamond)
                {
                    createObj.Status = ResultStatusEnum.IsNotDiamond.ToString();
                    orDetail.Status = ValuationDetailStatusEnum.Failed.ToString();
                    createObj.Carat = 0;
                    createObj.Clarity = "NaN";
                    createObj.Symmetry = "NaN";
                    createObj.Origin = "NaN";
                    createObj.Color = "NaN";
                    createObj.CutGrade = "NaN";
                    createObj.Description = "NaN";
                    createObj.DiamondValue = 0;
                    createObj.Shape = "NaN";
                    createObj.Fluorescence = "NaN";
                    createObj.Polish = "NaN";
                }
                else
                {
                    createObj.Status = ResultStatusEnum.Pending.ToString();
                }
                var rs = await _unitOfWork.ResultRepository.CreateAsync(createObj);
                
                if (rs != null)
                {
                    orDetail.ResultId = rs.ResultId;
                    var rsUpdate = await _unitOfWork.OrderDetailRepository.UpdateAsync(orDetail);

                    if (rs.IsDiamond && req.ClarityImages.Any() &&req.ProportionImages.Any())
                    {
                        var proportionImageUrls = req.ProportionImages;
                        foreach (var imageUrl in proportionImageUrls)
                        {
                            var resultImage = new ResultImage
                            {
                                ImageGuid = Guid.NewGuid(),
                                ResultID = rs.ResultId,
                                ImageType = "Proportions",
                                Status = "Active"
                            };
                            await _unitOfWork.ResultImageRepository.CreateAsync(resultImage);
                            var imagePath = FirebasePathName.RESULT + $"{resultImage.ImageGuid}";
                            var imageUploadResult = await _firebaseService.UploadFileToFirebase(imageUrl, imagePath);
                            if (imageUploadResult.Status == 500)
                            {
                                return new ServiceResult(500, "Error uploading files to Firebase.");
                            }

                            resultImage.ImageUrl = (string)imageUploadResult.Data;
                            _unitOfWork.ResultImageRepository.Update(resultImage);
                        }

                        var clarityImageUrls = req.ClarityImages;
                        foreach (var imageUrl in clarityImageUrls)
                        {
                            var resultImage = new ResultImage
                            {
                                ImageGuid = Guid.NewGuid(),
                                ResultID = rs.ResultId,
                                ImageType = "Clarity Characteristics",
                                Status = "Active"
                            };
                            await _unitOfWork.ResultImageRepository.CreateAsync(resultImage);
                            var imagePath = FirebasePathName.RESULT + $"{resultImage.ImageGuid}";
                            var imageUploadResult = await _firebaseService.UploadFileToFirebase(imageUrl, imagePath);
                            if (imageUploadResult.Status == 500)
                            {
                                return new ServiceResult(500, "Error uploading files to Firebase.");
                            }

                            resultImage.ImageUrl = (string)imageUploadResult.Data;
                            _unitOfWork.ResultImageRepository.Update(resultImage);
                        }
                    }

                    if (rsUpdate < 1)
                    {
                        return new ServiceResult(500, "Create failed");
                    }

                    return new ServiceResult(200, "Create successfully");
                }
                else
                {
                    return new ServiceResult(500, "Create failed");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> Update(int id, UpdateResultReq req)
        {
            try
            {
                var result = await _unitOfWork.ResultRepository.GetByIdAsync(id);
                if (result != null)
                {
                    var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(result.OrderDetailId);
                    var updateObj = _mapper.Map(req, result);
                    if(!updateObj.IsDiamond)
                    {
                        updateObj.Status = ResultStatusEnum.IsNotDiamond.ToString();
                        orderDetail.Status = ValuationDetailStatusEnum.Failed.ToString();
                        await _unitOfWork.OrderDetailRepository.UpdateAsync(orderDetail);
                        updateObj.Carat = 0;
                        updateObj.Clarity = "NaN";
                        updateObj.Symmetry = "NaN";
                        updateObj.Origin = "NaN";
                        updateObj.Color = "NaN";
                        updateObj.CutGrade = "NaN";
                        updateObj.Description = "NaN";
                        updateObj.DiamondValue = 0;
                        updateObj.Shape = "NaN";
                        updateObj.Fluorescence = "NaN";
                        updateObj.Polish = "NaN";
                    }
                    else
                    {
                        updateObj.Status = ResultStatusEnum.Pending.ToString();
                    }

                    var resultImages = await _unitOfWork.ResultImageRepository.GetByResultIdAsync(result.ResultId);
                    if (resultImages.Any())
                    {
                        foreach (var image in resultImages)
                        {
                            image.Status = "Inactive";
                            var isRemoved = await _unitOfWork.ResultImageRepository.RemoveAsync(image);
                            if (!string.IsNullOrEmpty(image.ImageUrl) && isRemoved)
                            {
                                string url = $"{FirebasePathName.RESULT}{image.ImageGuid}";
                                var deleteResult = await _firebaseService.DeleteFileFromFirebase(url);
                                if (!deleteResult.Status.Equals(200))
                                {
                                    return new ServiceResult(500, "Failed to delete old image");
                                }
                            }
                        }

                    }

                    var rs = await _unitOfWork.ResultRepository.UpdateAsync(updateObj);
                    if (rs > 0)
                    {
                        var proportionImageUrls = req.ProportionImages;
                        foreach (var imageUrl in proportionImageUrls)
                        {
                            var resultImage = new ResultImage
                            {
                                ImageGuid = Guid.NewGuid(),
                                ResultID = id,
                                ImageType = "Proportions",
                                Status = "Active"
                            };
                            await _unitOfWork.ResultImageRepository.CreateAsync(resultImage);
                            var imagePath = FirebasePathName.RESULT + $"{resultImage.ImageGuid}";
                            var imageUploadResult = await _firebaseService.UploadFileToFirebase(imageUrl, imagePath);
                            if (imageUploadResult.Status == 500)
                            {
                                return new ServiceResult(500, "Error uploading files to Firebase.");
                            }

                            resultImage.ImageUrl = (string)imageUploadResult.Data;
                            _unitOfWork.ResultImageRepository.Update(resultImage);
                        }

                        var clarityImageUrls = req.ClarityImages;
                        foreach (var imageUrl in clarityImageUrls)
                        {
                            var resultImage = new ResultImage
                            {
                                ImageGuid = Guid.NewGuid(),
                                ResultID = id,
                                ImageType = "Clarity Characteristics",
                                Status = "Active"
                            };
                            await _unitOfWork.ResultImageRepository.CreateAsync(resultImage);
                            var imagePath = FirebasePathName.RESULT + $"{resultImage.ImageGuid}";
                            var imageUploadResult = await _firebaseService.UploadFileToFirebase(imageUrl, imagePath);
                            if (imageUploadResult.Status == 500)
                            {
                                return new ServiceResult(500, "Error uploading files to Firebase.");
                            }

                            resultImage.ImageUrl = (string)imageUploadResult.Data;
                            _unitOfWork.ResultImageRepository.Update(resultImage);
                        }
                        return new ServiceResult(200, "Update successfully");
                    }
                    else
                    {
                        return new ServiceResult(500, "Update fail");
                    }
                }
                else
                {
                    return new ServiceResult(404, "Cannot find service detail");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }

        public async Task<IServiceResult> ChangeStatus(int id, ChangeStatusReq req)
        {
            try
            {
                var service = await _unitOfWork.ResultRepository.GetByIdAsync(id);
                if (service != null)
                {
                    service.Status = req.Status;
                    var rs = await _unitOfWork.ResultRepository.UpdateAsync(service);
                    if (rs > 0)
                    {
                        return new ServiceResult(200, "Change status successfully");
                    }
                    else
                    {
                        return new ServiceResult(500, "change status fail");
                    }
                }
                else
                {
                    return new ServiceResult(404, "Cannot find ervice");
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult(500, ex.Message);
            }
        }
    }
}
