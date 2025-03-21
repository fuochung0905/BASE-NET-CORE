using MODELS.BASE;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.DUAN.QUANLICONGVIEC_CHITIET.Dtos;
using Model.BASE;

namespace REPONSITORY.DUAN.QUANLYCONGVIECCHITIET
{
    public interface IQUANLICONGVIECCHITIETService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListCongViecChiTietRequest request);
        BaseResponse<PostQuanLiCongViec_ChiTietRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELQuanLiCongViecChiTiet> Update(PostQuanLiCongViec_ChiTietRequest request);
    }
}
