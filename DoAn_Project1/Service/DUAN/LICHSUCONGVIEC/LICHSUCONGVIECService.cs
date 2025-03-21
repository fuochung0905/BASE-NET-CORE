using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoDependencyRegistration.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using MODELS.BASE;
using MODELS;
using Azure.Core;
using MODELS.DUAN.LICHSUCONGVIEC.Dtos;
using MODELS.DUAN.LICHSUCONGVIEC.Request;
using Repository;
using Model.BASE;

namespace REPONSITORY.DUAN.LICHSUCONGVIEC
{
    [RegisterClassAsTransient]
    public class LICHSUCONGVIECService : ILICHSUCONGVIECService
    {
        private IUnitOfWork _unitOfWork;
        public LICHSUCONGVIECService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public BaseResponse<GetListPagingResponse> GetList(PostLichSuCongViecGetListPaingRequets requets)
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
                var parameters = new[]
                {
                    new SqlParameter("@iPageIndex", requets.PageIndex),
                    new SqlParameter("@iRowsPerPage", requets.RowPerPage),
                    new SqlParameter("@iCongViecId", requets.CongViecId),
                    iTotalRow
                };
                var result = _unitOfWork.GetRepository<MODELLichSuCongViec>().ExcuteStoredProcedure("sp_LICHSUCONGVIECTHEOIDCONGVIEC_GetListPaging", parameters)
                    .ToList();
                var responseData = new GetListPagingResponse
                {
                    PageIndex = requets.PageIndex,
                    Data = result,
                    TotalRow = Convert.ToInt32(iTotalRow.Value)
                };
                response.Data = responseData;
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
            return response;
        }

        public BaseResponse<GetListPagingResponse> GetList(GetByIdRequest requets)
        {
            BaseResponse<GetListPagingResponse> response = new BaseResponse<GetListPagingResponse>();
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@iCongViecId", requets.Id)
                };
                var result = _unitOfWork.GetRepository<MODELLichSuCongViec>().ExcuteStoredProcedure("sp_XEMLICHSUCONGVIEC_GetListPaging", parameters)
                    .ToList();
                var responseData = new GetListPagingResponse
                {
                    Data = result,
                };
                response.Data = responseData;
            }
            catch (Exception e)
            {
                response.Error = true;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
