using AutoMapper;
using ENTITIES.DBContent;
using MODELS.DANHMUC.MONHOC.Dtos;
using MODELS.DANHMUC.MONHOC.Requests;
using MODELS.DANHMUC.NIENKHOA.Dtos;
using MODELS.DANHMUC.NIENKHOA.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DANHMUC.NIENKHOA
{
    public class NIENKHOAProfile : Profile
    {
        public NIENKHOAProfile() 
        {
            CreateMap<DM_NIENKHOA, MODELNienKhoa>();
            CreateMap<MODELNienKhoa, DM_NIENKHOA>();
            CreateMap<PostNienKhoaRequest, DM_NIENKHOA>();
            CreateMap<DM_NIENKHOA, PostNienKhoaRequest>();
        }
    }
}
