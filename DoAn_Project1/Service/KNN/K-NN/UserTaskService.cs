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
        public static List<TaskRecord> SimulateTaskList(string label)
        {
            var rand = new Random();
            int n = rand.Next(5, 10);
            var list = new List<TaskRecord>();

            for (int i = 0; i < n; i++)
            {
                int difficulty = label switch
                {
                    "Giỏi" => rand.Next(2, 4), 
                    "Khá" => rand.Next(1, 3),
                    "Trung Bình" => rand.Next(1, 3),
                    "Yếu" => 1,
                    _ => 1
                };

                double est = rand.NextDouble() * (difficulty + 1) + 1;
                double act = est + rand.NextDouble();

                int eval = label switch
                {
                    "Giỏi" => rand.Next(3, 5),
                    "Khá" => rand.Next(2, 4),
                    "Trung Bình" => rand.Next(2, 3),
                    "Yếu" => rand.Next(1, 2),
                    _ => 2
                };

                int status = label == "Yếu" ? rand.Next(1, 5) : 5;

                list.Add(new TaskRecord
                {
                    Difficulty = difficulty,
                    EstimatedTime = Math.Round(est, 2),
                    ActualTime = Math.Round(act, 2),
                    EvaluationScore = eval,
                    Status = status
                });
            }

            return list;
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
                EvaluationScore = x.DanhGiaCongViec.Value
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

        public static List<List<UserTasks>> DistributeBalancedGroups(List<UserTasks> allStudents)
        {
            var grouped = allStudents
                .GroupBy(s => s.Label)
                .ToDictionary(g => g.Key, g => new Queue<UserTasks>(g));

            int totalStudents = allStudents.Count;
            int groupSize = 4;
            int totalGroups = totalStudents / groupSize;

            var result = new List<List<UserTasks>>();

            for (int i = 0; i < totalGroups; i++)
            {
                var group = new List<UserTasks>();

                foreach (var label in new[] { "Giỏi", "Khá", "Trung Bình", "Yếu" })
                {
                    if (grouped.ContainsKey(label) && grouped[label].Count > 0)
                    {
                        group.Add(grouped[label].Dequeue());
                    }
                }

                while (group.Count < groupSize)
                {
                    var nonEmptyGroups = grouped.Where(g => g.Value.Count > 0).ToList();
                    if (nonEmptyGroups.Count == 0) break;

                    var randomGroup = nonEmptyGroups[new Random().Next(nonEmptyGroups.Count)];
                    group.Add(randomGroup.Value.Dequeue());
                }

                result.Add(group);
            }

            return result;
        }

    }
}
