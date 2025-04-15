using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.Dtos;
using MODELS.DANHMUC.MONHOC.Dtos;
using MODELS.DANHMUC.MONHOC.Requests;
using MODELS.DANHMUC.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DANHMUC.MONHOC
{
    public class MONHOCProfile : Profile
    {
        public MONHOCProfile() 
        {
            CreateMap<DM_MONHOC, MODELMonHoc>();
            CreateMap<MODELMonHoc, DM_MONHOC>();
            CreateMap<PostMonHocRequest, DM_MONHOC>();
            CreateMap<DM_MONHOC, PostMonHocRequest>();
        }
    }
}
