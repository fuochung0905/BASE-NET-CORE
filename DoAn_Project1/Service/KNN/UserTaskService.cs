using AutoDependencyRegistration.Attributes;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS.K_MEAN.Dtos;
using MODELS.K_MEAN.Requests;
using MODELS.KNN.Dtos;
using Repository;
using Service.KNN;

namespace Service.K_MEAN
{
    [RegisterClassAsTransient]
    public class UserTaskService : IUserTaskService
    {
        private IUnitOfWork _unitOfWork;
        public UserTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public BaseResponse<GetListPagingResponse> GetList(PostUserTaskGetListRequest request)
        {
            BaseResponse<GetListPagingResponse> response = new BaseResponse<GetListPagingResponse>();
            try
            {
                SqlParameter iTotalRow = new SqlParameter()
                {
                    ParameterName = "@oTotalRow",
                    SqlDbType = System.Data.SqlDbType.BigInt,
                    Direction = System.Data.ParameterDirection.Output
                };

                var parameters = new[]
                {
                    new SqlParameter("@iPhongBanId", request.PhongBanId.HasValue ? request.PhongBanId : DBNull.Value),
                    new SqlParameter("@iDonViId", request.DonViId),
                    new SqlParameter("@iVaiTroId", request.VaiTroId),
                    new SqlParameter("@iNienKhoaId", request.NienKhoaId),
                    new SqlParameter("@iTextSearch", request.TextSearch),
                    new SqlParameter("@iPageIndex", request.PageIndex),
                    new SqlParameter("@iRowsPerPage", request.RowPerPage),
                    iTotalRow
                };

                var result = _unitOfWork.GetRepository<UserTasks>().ExcuteStoredProcedure("sp_UserTask_GetListPaging", parameters).ToList();
                GetListPagingResponse resposeData = new GetListPagingResponse();
                resposeData.PageIndex = request.PageIndex;
                resposeData.Data = result;
                resposeData.TotalRow = Convert.ToInt32(iTotalRow.Value);
                response.Data = resposeData;
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public BaseResponse<List<UserTasks>> GetPhanLoaiSinhVien()
        {
            BaseResponse<List<UserTasks>> response = new BaseResponse<List<UserTasks>>();
            List<UserTasks> trainingSet = new()
            {
                new UserTasks { EasyTaskCount = 2, MediumTaskCount = 3, HardTaskCount = 5, TotalEstimatedHours = 50, TotalActualHours = 48, CompletionRate = 0.9, AverageEfficiency = 1.05, Label = "Giỏi" },
                new UserTasks { EasyTaskCount = 4, MediumTaskCount = 4, HardTaskCount = 2, TotalEstimatedHours = 42, TotalActualHours = 44, CompletionRate = 0.7, AverageEfficiency = 0.95, Label = "Khá" },
                new UserTasks { EasyTaskCount = 5, MediumTaskCount = 2, HardTaskCount = 1, TotalEstimatedHours = 36, TotalActualHours = 40, CompletionRate = 0.6, AverageEfficiency = 0.85, Label = "Trung Bình" },
                new UserTasks { EasyTaskCount = 6, MediumTaskCount = 1, HardTaskCount = 0, TotalEstimatedHours = 30, TotalActualHours = 38, CompletionRate = 0.4, AverageEfficiency = 0.70, Label = "Yếu" },
            };
            Dictionary<string, List<TaskRecord>> classTasks = new()
            {
                ["Nguyễn Văn A"] = new List<TaskRecord>
                {
                    new TaskRecord { Difficulty = 1, EstimatedTime = 2, ActualTime = 2 },
                    new TaskRecord { Difficulty = 3, EstimatedTime = 5, ActualTime = 5 },
                    new TaskRecord { Difficulty = 2, EstimatedTime = 4, ActualTime = 4 }
                },
                ["Trần Thị B"] = new List<TaskRecord>
                {
                    new TaskRecord { Difficulty = 1, EstimatedTime = 1.5, ActualTime = 2 },
                    new TaskRecord { Difficulty = 1, EstimatedTime = 1, ActualTime = 1.5 }
                }
            };

            var results = KNNClassifier.ClassifyClass(classTasks, trainingSet, k: 3);

            foreach (var student in results)
            {
                Console.WriteLine($"{student.Name} → {student.Label}");
            }
            return response;
        }
    }
}
