using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DANHMUC.GIAIDOANDUAN.Dtos;
using MODELS.DANHMUC.GIAIDOANDUAN.Requests;

namespace REPONSITORY.DANHMUC.GIAIDOANDUAN
{
	public interface IGIAIDOANDUANService
	{
		BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
		BaseResponse<MODELGiaiDoanDuAn> GetById(GetByIdRequest request);
		BaseResponse<PostGiaiDoanDuAnRequest> GetByPost(GetByIdRequest request);
		BaseResponse<MODELGiaiDoanDuAn> Insert(PostGiaiDoanDuAnRequest request);
		BaseResponse<MODELGiaiDoanDuAn> Update(PostGiaiDoanDuAnRequest request);
		BaseResponse<string> Delete(DeleteRequest request);
		BaseResponse<string> DeleteList(DeleteListRequest request);
		BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
	}
}
