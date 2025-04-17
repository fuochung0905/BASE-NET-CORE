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
using MODELS.DANHMUC.NIENKHOA.Dtos;
using MODELS.DANHMUC.NIENKHOA.Request;

namespace Service.DANHMUC.NIENKHOA
{
    public interface INIENKHOAService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELNienKhoa> GetById(GetByIdRequest request);
        BaseResponse<PostNienKhoaRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELNienKhoa> Insert(PostNienKhoaRequest request);
        BaseResponse<MODELNienKhoa> Update(PostNienKhoaRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }
}
