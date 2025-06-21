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

            var completed = tasks.Where(t => t.Status == 5).ToList();

            var completionRate = completed.Count / (double)(total == 0 ? 1 : total);
            var efficiency = act == 0 ? 0 : est / act;
            var avgEval = completed.Any() ? completed.Average(t => t.EvaluationScore) : 0;

            return new UserTasks
            {
                Name = name,
                EasyTaskCount = easy,
                MediumTaskCount = medium,
                HardTaskCount = hard,
                TotalEstimatedHours = est,
                TotalActualHours = act,
                CompletionRate = Math.Round(completionRate, 2),
                AverageEfficiency = Math.Round(efficiency, 2),
                CompletedTaskCount = completed.Count,
                TotalTaskCount = total,
                TaskCompletionRatio = Math.Round(completionRate, 2),
                AverageTaskEvaluation = Math.Round(avgEval, 2),
            };
        }

    }
}
