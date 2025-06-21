using MODELS.K_MEAN.Dtos;
using MODELS.KNN.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.KNN
{
    public static class ConvertToUser
    {
        public static UserTasks ConvertToStudent(string name, List<TaskRecord> tasks)
        {
            int total = tasks.Count;
            if (total == 0) return null;

            int easy = tasks.Count(t => t.Difficulty == 1);
            int medium = tasks.Count(t => t.Difficulty == 2);
            int hard = tasks.Count(t => t.Difficulty == 3);
            double est = tasks.Sum(t => t.EstimatedTime);
            double act = tasks.Sum(t => t.ActualTime);

            int onTime = tasks.Count(t => t.ActualTime <= t.EstimatedTime);
            double efficiencySum = tasks.Sum(t => t.EstimatedTime / (t.ActualTime == 0 ? 1 : t.ActualTime));

            return new UserTasks
            {
                Name = name,
                EasyTaskCount = easy,
                MediumTaskCount = medium,
                HardTaskCount = hard,
                TotalEstimatedHours = est,
                TotalActualHours = act,
                CompletionRate = (double)onTime / total,
                AverageEfficiency = efficiencySum / total
            };
        }

    }
}
