using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.TRANGTHAICONGVIEC.Dtos;
using MODELS.DUAN.TRANGTHAICONGVIEC.Request;

namespace REPONSITORY.DUAN.TRANGTHAICONGVIEC
{
    public interface ITRANGTHAICONGVIECService
    {
	    BaseResponse<GetListPagingResponse> GetListCongViec(PostTrangThaiCongViecGetListPagingRequest request);
        BaseResponse<List<MODELTrangThaiCongViec>> GetListTrangThaiCongViec();
        BaseResponse<MODELCongViec> UpdateTrangThaiCongViec(PostTrangThaiCongViecRequest request);
        BaseResponse<MODELCheckPhanQuyen> CheckRoleUser();
        BaseResponse<MODELQuanLyCongViec> GetById(GetByIdRequest request);
        BaseResponse<MODELCongViec> UpdateCongViecByTrangThai(PostCongViecByTrangThaiRequest request);
    }
}
