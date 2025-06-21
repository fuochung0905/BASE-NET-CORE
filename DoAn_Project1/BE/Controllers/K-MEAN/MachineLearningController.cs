using BE.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.BASE;
using MODELS.K_MEAN.Requests;
using REPONSITORY.HETHONG.VAITRO;
using Service.K_MEAN;

namespace BE.Controllers.K_MEAN
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineLearningController : ControllerBase
    {
        IUserTaskService _service;

        public MachineLearningController(IUserTaskService service)
        {
            _service = service;
        }

        [HttpPost, Route("userTask/get-list-paging")]
        [AllowAnonymous]
        public IActionResult GetListPaging(PostUserTaskGetListRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(MODELS.COMMON.CommonFunc.GetModelStateAPI(ModelState));
                }
                var result = _service.GetList(request);
                if (result.Error)
                {
                    throw new Exception(result.Message);
                }
                else
                {
                    return Ok(new ApiOkResponse(result.Data));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(false, 500, ex.Message));
            }
        }
    }
}
