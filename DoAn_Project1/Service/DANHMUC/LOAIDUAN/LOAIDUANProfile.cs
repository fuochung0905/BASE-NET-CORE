using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.LOAIDUAN.Dtos;
using MODELS.DANHMUC.LOAIDUAN.Requests;
using MODELS.DANHMUC.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DANHMUC.LOAIDUAN
{
    public class LOAIDUANProfile : Profile
    {
        public LOAIDUANProfile() 
        {
            CreateMap<DM_LOAIDUAN, MODELLoaiDuAn>();
            CreateMap<MODELLoaiDuAn, DM_LOAIDUAN>();
            CreateMap<PostLoaiDuAnRequest, DM_LOAIDUAN>();
            CreateMap<DM_LOAIDUAN, PostLoaiDuAnRequest>();
        }
    }
}
