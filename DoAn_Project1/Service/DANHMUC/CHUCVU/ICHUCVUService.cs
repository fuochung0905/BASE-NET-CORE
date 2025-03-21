using MODELS.BASE;
using MODELS.DANHMUC.CHUCVU.Dtos;
using MODELS.DANHMUC.CHUCVU.Requests;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;

namespace REPONSITORY.DANHMUC.CHUCVU
{
    public interface ICHUCVUService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELChucVu> GetById(GetByIdRequest request);
        BaseResponse<PostChucVuRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELChucVu> Insert(PostChucVuRequest request);
        BaseResponse<MODELChucVu> Update(PostChucVuRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
