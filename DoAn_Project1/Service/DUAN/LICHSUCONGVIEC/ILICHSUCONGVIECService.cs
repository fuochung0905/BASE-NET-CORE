using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS;
using MODELS.BASE;
using MODELS.DUAN.LICHSUCONGVIEC.Request;

namespace REPONSITORY.DUAN.LICHSUCONGVIEC
{
    public interface ILICHSUCONGVIECService
    {
        BaseResponse<GetListPagingResponse> GetList(PostLichSuCongViecGetListPaingRequets requets);
        BaseResponse<GetListPagingResponse> GetList(GetByIdRequest requets);
    }
}
