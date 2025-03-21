using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;

namespace REPONSITORY.DUAN.QUANLYCONGVIEC;

public interface IQUANLYCONGVIECService
{
	BaseResponse<GetListPagingResponse> GetList(GetListQuanLyCongViecRequest request);
    
    

    BaseResponse<MODELQuanLyCongViec> GetById(GetByIdRequest request);
	BaseResponse<PostQuanLyCongViecRequest> GetByPost(GetByIdRequest request);
	BaseResponse<MODELQuanLyCongViec> Insert(PostQuanLyCongViecRequest request);
	BaseResponse<MODELQuanLyCongViec> Update(PostQuanLyCongViecRequest request);
	BaseResponse<string> Delete(DeleteRequest request);
	BaseResponse<string> DeleteList(DeleteListRequest request);
    BaseResponse<List<MODELCombobox>> GetAllComboBox(PostQuanLyCongViecGetAllRequest request);
    BaseResponse<List<MODELCombobox>> GetAllComboBoxWithDuAn(PostQuanLyCongViecGetAllRequest request);
    BaseResponse<List<MODELCombobox>> GetComboBoxTrangThai(GetAllRequest request);
    BaseResponse<List<MODELCombobox>> GetComboBoxTrangThaiForUserName(GetAllRequest request);
    BaseResponse<List<MODELTongSoCongViec>> GetTongSoCongViec(PostTongSoCongViecRequest request);
    BaseResponse<MODELTongSoGioCong> GetTongSoGioCongTrongCongViec(PostTongSoCongViecRequest request);
    BaseResponse<List<MODELCombobox>> GetAllForComboboxChiTietCongViec(PostQuanLyCongViecRequest request);

 
}