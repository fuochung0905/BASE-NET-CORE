using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.QUANLYDUAN.Dtos;
using MODELS.DUAN.QUANLYDUAN.Requests;

namespace REPONSITORY.DUAN.QUANLYDUAN;
public interface IQUANLYDUANService
{
    BaseResponse<GetListPagingResponse> GetList(GetListQuanLyDuAnRequest request);
    BaseResponse<MODELQuanLyDuAn> GetById(GetByIdRequest request);
    BaseResponse<PostQuanLyDuAnRequest> GetByPost(GetByIdRequest request);
    BaseResponse<MODELQuanLyDuAn> Insert(PostQuanLyDuAnRequest request);
    BaseResponse<MODELQuanLyDuAn> Update(PostQuanLyDuAnRequest request);
    BaseResponse<string> Delete(DeleteRequest request);
    BaseResponse<string> DeleteList(DeleteListRequest request);
    BaseResponse<List<MODELCombobox>> GetAllComboBox(GetAllRequest request);
  
}
