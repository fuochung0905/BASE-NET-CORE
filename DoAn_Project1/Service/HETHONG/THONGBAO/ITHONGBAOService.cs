using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.HETHONG.HETHONGTHONGBAO.Dtos;
using MODELS.HETHONG.HETHONGTHONGBAO.Requests;

namespace REPONSITORY.HETHONG.THONGBAO
{
    public interface ITHONGBAOService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELThongBao> GetById(GetByIdRequest request);
        BaseResponse<PostThongBaoRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELThongBao> Insert(PostThongBaoRequest request);
        BaseResponse<MODELThongBao> Update(PostThongBaoRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
        BaseResponse<int> SoLuongThongBaoNguoiDung();
    }
}
