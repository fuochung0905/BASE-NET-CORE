using Model.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DANHMUC.TEAM.Requests
{
    public class PostTeamRequest : BaseRequest
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã team không được để trống")]
        public string Ma { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên team không được để trống")]
        public string TenGoi { get; set; } = null!;
    }
}
