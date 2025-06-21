using AutoDependencyRegistration.Attributes;
using ENTITIES.DBContent;
using Microsoft.Data.SqlClient;
using Model.BASE;
using MODELS.K_MEAN.Dtos;
using MODELS.K_MEAN.Requests;
using MODELS.KNN.Dtos;
using Repository;
using Service.KNN;
using System.Text.Json;

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

        private List<UserTasks> getDataSet()
        {
            string filePath = @"C:\BASE-NET-CORE\DoAn_Project1\Service\KNN\DataSet\trainingSet.json";
            List<UserTasks> trainingSet = new List<UserTasks>();
            if (!File.Exists(filePath))
                return trainingSet;

            string json = File.ReadAllText(filePath);
            trainingSet = JsonSerializer.Deserialize<List<UserTasks>>(json);
            return trainingSet;
        }

        private List<TaskRecord> getListTaskWithUserName(Guid Id)
        {
             List<TaskRecord> result = new List<TaskRecord>();
             result = _unitOfWork.GetRepository<DUAN_QUANLYCONGVIEC>().GetAll().Where(x =>x.AssignTo == Id).Select(x => new TaskRecord
             {
                 Difficulty = x.DoKhoCongViec,
                 EstimatedTime = x.GioCongDuKien.Value,
                 ActualTime = x.SoGioThucTe.Value,
                Status = x.TrangThaiId,
                EvaluationScore = x.DanhGiaCongViec
             }
             ).ToList();
            return result;
        }

        public BaseResponse<List<UserTasks>> GetPhanLoaiSinhVien()
        {
            BaseResponse<List<UserTasks>> response = new BaseResponse<List<UserTasks>>();
            List<UserTasks> trainingSet = getDataSet();
            Dictionary<string, List<TaskRecord>> classTasks = new Dictionary<string, List<TaskRecord>>();
            List<TAIKHOAN> taikhoans = _unitOfWork
                .GetRepository<ENTITIES.DBContent.TAIKHOAN>()
                .GetAll()
                .Select(x => new TAIKHOAN
                {
                    Id = x.Id,
                    UserName = x.UserName
                })
                .ToList();
            foreach(var item in taikhoans)
                classTasks[item.UserName] = getListTaskWithUserName(item.Id);

            var results = KNNClassifier.ClassifyClass(classTasks, trainingSet, k: 3);

           response.Data = results;
           response.Error = false;
           response.Message = "Phân loai thành công";
           return response;
        }
    }
}
