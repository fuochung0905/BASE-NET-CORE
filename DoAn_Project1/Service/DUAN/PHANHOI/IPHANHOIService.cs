using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.PHANHOI.Dtos;
using MODELS.DUAN.PHANHOI.Requests;
using MODELS.DUAN.QUANLYCONGVIEC.Dtos;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;

namespace REPONSITORY.DUAN.PHANHOI
{
    public interface IPHANHOIService
    {
        BaseResponse<GetListPagingResponse> GetList(PostPhanHoiGetListPagingRequest request);
        BaseResponse<MODELQuanLyCongViec_PhanHoi> GetById(GetByIdRequest request);
        BaseResponse<PostPhanHoiRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELQuanLyCongViec_PhanHoi> Insert(PostPhanHoiRequest request);
        BaseResponse<MODELQuanLyCongViec_PhanHoi> Update(PostPhanHoiRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);

    }
}
