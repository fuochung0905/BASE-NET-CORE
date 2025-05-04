using Model.BASE;
using MODELS.BASE;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.Requests;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.DANHMUC.LOAIDUAN.Dtos;
using MODELS.DANHMUC.LOAIDUAN.Requests;

namespace Service.DANHMUC.LOAIDUAN
{
    public interface ILOAIDUANService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELLoaiDuAn> GetById(GetByIdRequest request);
        BaseResponse<PostLoaiDuAnRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELLoaiDuAn> Insert(PostLoaiDuAnRequest request);
        BaseResponse<MODELLoaiDuAn> Update(PostLoaiDuAnRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
