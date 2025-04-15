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
using MODELS.DANHMUC.TEAM.Dtos;
using MODELS.DANHMUC.TEAM.Requests;

namespace Service.DANHMUC.TEAM
{
    public interface ITEAMService
    {
        BaseResponse<GetListPagingResponse> GetList(GetListPagingRequest request);
        BaseResponse<MODELTeam> GetById(GetByIdRequest request);
        BaseResponse<PostTeamRequest> GetByPost(GetByIdRequest request);
        BaseResponse<MODELTeam> Insert(PostTeamRequest request);
        BaseResponse<MODELTeam> Update(PostTeamRequest request);
        BaseResponse<string> Delete(DeleteRequest request);
        BaseResponse<string> DeleteList(DeleteListRequest request);
        BaseResponse<List<MODELCombobox>> GetAllForCombobox(GetAllRequest request);
    }

}
