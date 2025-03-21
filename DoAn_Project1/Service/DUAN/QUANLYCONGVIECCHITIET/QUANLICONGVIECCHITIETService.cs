using AutoDependencyRegistration.Attributes;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MODELS.BASE;

using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Dtos;
using MODELS.DUAN.QUANLYDUAN.Dtos;
using MODELS.DUAN.QUANLYDUAN.Requests;
using Repository;
using Model.BASE;

namespace REPONSITORY.DUAN.QUANLYCONGVIECCHITIET
{
    [RegisterClassAsTransient]
    public class QUANLICONGVIECCHITIETService : IQUANLICONGVIECCHITIETService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public QUANLICONGVIECCHITIETService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor contextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _webHostEnvironment = webHostEnvironment;
        }

        //GET LIST
        public BaseResponse<GetListPagingResponse> GetList(GetListCongViecChiTietRequest request)
        {
            var response = new BaseResponse<GetListPagingResponse>();
            try
            {
                SqlParameter iTotalRow = new()
                {
                    ParameterName = "@oTotalRow",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output
                };

                var parameters = new[]
                {
                new SqlParameter("@iTaiKhoanId", request.TaiKhoanId),
                new SqlParameter("@iTuNgay", request.TuNgay),
                new SqlParameter("@iDenNgay", request.DenNgay),
                new SqlParameter("@iTextSearch", request.TextSearch),   
                new SqlParameter("@iPageIndex", request.PageIndex),
                new SqlParameter("@iRowsPerPage", request.RowPerPage),
                iTotalRow
            };

                var result = _unitOfWork.GetRepository<MODELQuanLiCongViecChiTiet>().ExcuteStoredProcedure("sp_DUAN_QUANLYCONGVIEC_CHITIET_GetListPaging", parameters).ToList();
                var responseData = new GetListPagingResponse
                {
                    PageIndex = request.PageIndex,
                    Data = result,
                    TotalRow = Convert.ToInt32(iTotalRow.Value)
                };
                response.Data = responseData;

            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
        //GET BY POST (INSERT/UPDATE)
        public BaseResponse<PostQuanLiCongViec_ChiTietRequest> GetByPost(GetByIdRequest request)
        {
            var response = new BaseResponse<PostQuanLiCongViec_ChiTietRequest>();
            try
            {
                var result = new PostQuanLiCongViec_ChiTietRequest();
                var data = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_CHITIET>().Find(x => x.Id == request.Id);
                if (data is null)
                {
                    result.Id = Guid.NewGuid();
                    result.IsEdit = false;
                }
                else
                {
                    result = _mapper.Map<PostQuanLiCongViec_ChiTietRequest>(data);
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
        //UPDATE
        public BaseResponse<MODELQuanLiCongViecChiTiet> Update(PostQuanLiCongViec_ChiTietRequest request)
        {
            var response = new BaseResponse<MODELQuanLiCongViecChiTiet>();
            try
            {
                var isExist = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_CHITIET>()
                    .Find(x => x.Id != request.Id && x.Id == request.Id);
                if (isExist is not null)
                {
                    throw new Exception("Dữ liệu đã tồn tại");
                }
                var update = _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_CHITIET>().Find(x => x.Id == request.Id);
                if (update is not null)
                {
                    _mapper.Map(request, update);
                    update.NguoiSua = _contextAccessor.HttpContext.User.Identity.Name;
                    update.NgaySua = DateTime.Now;

                    _unitOfWork.GetRepository<ENTITIES.DBContent.DUAN_QUANLYCONGVIEC_CHITIET>().update(update);
                    _unitOfWork.Commit();

                    response.Data = _mapper.Map<MODELQuanLiCongViecChiTiet>(update);
                }
                else
                {
                    throw new Exception("Không tìm thấy dữ liệu");
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
