using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.MONHOC.Dtos;
using MODELS.DANHMUC.MONHOC.Requests;

namespace Service.DANHMUC.MONHOC
{
    public interface IMONHOCService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELMonHoc> GetById(GetByIdRequest request);
        BaseResponse<PostMonHocRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELMonHoc> Insert(PostMonHocRequest request);
        BaseResponse<MODELMonHoc> Update(PostMonHocRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
