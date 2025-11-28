using Model.BASE;
using MODELS.HETHONG.TAIKHOAN.Requests;
using MODELS.K_MEAN.Dtos;
using MODELS.K_MEAN.Requests;
using MODELS.KNN.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.K_MEAN
{
    public interface IUserTaskService
    {
        BaseResponse<List<UserTasks>> GetPhanLoaiSinhVien();
        BaseResponse<List<GroupStudent>> DistributeBalancedGroupsWithGroupNumber();
    }
}
