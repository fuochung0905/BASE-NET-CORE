using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.GIAIDOANDUAN.Dtos;
using MODELS.DANHMUC.GIAIDOANDUAN.Requests;

namespace REPONSITORY.DANHMUC.GIAIDOANDUAN
{
	public class GIAIDOANDUANProfile : Profile
	{
		public GIAIDOANDUANProfile()
		{
			CreateMap<DM_GIAIDOANDUAN, MODELGiaiDoanDuAn>();
			CreateMap<MODELGiaiDoanDuAn, DM_GIAIDOANDUAN>();
			CreateMap<PostGiaiDoanDuAnRequest, DM_GIAIDOANDUAN>();
			CreateMap<DM_GIAIDOANDUAN, PostGiaiDoanDuAnRequest>();
		}
	}
}
