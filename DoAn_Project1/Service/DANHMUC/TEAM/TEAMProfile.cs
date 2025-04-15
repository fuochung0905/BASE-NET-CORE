using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.Requests;
using MODELS.DANHMUC.TEAM.Dtos;
using MODELS.DANHMUC.TEAM.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DANHMUC.TEAM
{
    public class TEAMProfile : Profile
    {
        public TEAMProfile() 
        {
            CreateMap<DM_TEAM, MODELTeam>();
            CreateMap<MODELTeam, DM_TEAM>();
            CreateMap<PostTeamRequest, DM_TEAM>();
            CreateMap<DM_TEAM, PostTeamRequest>();
        }
    }
}
