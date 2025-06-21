using Model.BASE;
using MODELS.HETHONG.TAIKHOAN.Requests;
using MODELS.K_MEAN.Dtos;
using MODELS.K_MEAN.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.K_MEAN
{
    public interface IUserTaskService
    {
        BaseResponse<GetListPagingResponse> GetList(PostUserTaskGetListRequest request);
        BaseResponse<List<UserTasks>> GetPhanLoaiSinhVien();
    }
}
