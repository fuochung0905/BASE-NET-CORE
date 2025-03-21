using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoDependencyRegistration.Attributes;
using AutoMapper;
using ENTITIES.DBContent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.PHANHOI.Dtos;
using MODELS.DUAN.PHANHOI.Requests;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using Repository;

namespace REPONSITORY.DUAN.PHANHOI
{
    [RegisterClassAsTransient]
    public class PHANHOIService : IPHANHOIService
    {
        private  IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IHttpContextAccessor _contextAccessor;
        public PHANHOIService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public BaseResponse<GetListPagingResponse> GetList(PostPhanHoiGetListPagingRequest request)
        {
            BaseResponse<GetListPagingResponse> response = new BaseResponse<GetListPagingResponse>();
            try
            {
                SqlParameter iTotalRow = new SqlParameter()
                {
                    ParameterName = "@oTotalRow",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output
                };
                var parameters = new[] {
                    new SqlParameter("@iCongViecId", request.CongViecId.HasValue ? request.CongViecId : DBNull.Value),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };
                var result = _unitOfWork.GetRepository<MODELQuanLyCongViec_PhanHoi>()
                    .ExcuteStoredProcedure("sp_CONGVIECPHANHOI_GETLISTPAGING", parameters)
                    .ToList();
                var responseData = new GetListPagingResponse
                {
                    PageIndex = request.PageIndex,
                    Data = result,
                    TotalRow = Convert.ToInt32(iTotalRow.Value)
                };
                response.Data = responseData;
            }
            catch (Exception ex) {
                response.Error = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse<MODELQuanLyCongViec_PhanHoi> GetById(GetByIdRequest request)
        {
            var response = new BaseResponse<MODELQuanLyCongViec_PhanHoi>();
            try
            {
                var data = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>()
                    .Find(x => x.Id == request.Id && x.IsDeleted == false);
                if (data == null)
                {
                    throw new Exception("Không tồn tại dữ liệu");
                }
                else
                {
                    var responseData = _mapper.Map<MODELQuanLyCongViec_PhanHoi>(data);
                    response.Data = responseData;
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
            return response;
        }

        public BaseResponse<PostPhanHoiRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostPhanHoiRequest>();
            try
            {
                var result = new PostPhanHoiRequest();
                var data = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>().Find(x => x.Id == request.Id);
                if (data is null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostPhanHoiRequest>(data);
                    result.IsEdit = true;
                }
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public BaseResponse<MODELQuanLyCongViec_PhanHoi> Insert(PostPhanHoiRequest request)
        {
            var response = new BaseResponse<MODELQuanLyCongViec_PhanHoi>();
            try
            {
                var add = _mapper.Map<DUAN_QUANLYCONGVIEC_PHANHOI>(request);
                var userId = _unitOfWork.GetRepository<TAIKHOAN>().Find(x => x.UserName == _contextAccessor.HttpContext.User.Identity.Name);  ;
                add.Id = Guid.NewGuid();
                add.NguoiGuiId = userId.Id;
                add.NgayGui = DateTime.Now;
                _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>().add(add);
                _unitOfWork.Commit();
                response.Data = _mapper.Map<MODELQuanLyCongViec_PhanHoi>(add);
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }
            return response;
        }

        public BaseResponse<MODELQuanLyCongViec_PhanHoi> Update(PostPhanHoiRequest request)
        {
            var response = new BaseResponse<MODELQuanLyCongViec_PhanHoi>();
            try
            {
                var update = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>().Find(x => x.Id == request.Id);
                if (update != null)
                {
                    update.NoiDungHtml = request.NoiDungHtml;
                    _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>().update(update);
                    _unitOfWork.Commit();
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
            return response;
        }

        public BaseResponse<string> Delete(DeleteRequest request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var delete = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>().Find(x => x.Id == request.Id);
                if (delete != null)
                {
                    delete.IsDeleted =true;
                    _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC_PHANHOI>().update(delete);
                    _unitOfWork.Commit();
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }

            return response;
        }

        public BaseResponse<string> DeleteList(DeleteListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
