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
            if (tasks == null || tasks.Count == 0) return null;

            var cleanedTasks = tasks
                .Where(t => t != null) 
                .Select(t => new TaskRecord
                {
                    Difficulty = (t.Difficulty >= 1 && t.Difficulty <= 3) ? t.Difficulty : 1, 
                    EstimatedTime = (t.EstimatedTime >= 0 && t.EstimatedTime <= 100) ? t.EstimatedTime : 0, 
                    ActualTime = (t.ActualTime >= 0 && t.ActualTime <= 1000) ? t.ActualTime : 0,
                    EvaluationScore = (t.EvaluationScore >= 0 && t.EvaluationScore <= 10) ? t.EvaluationScore : 0,
                    Status = t.Status
                }).ToList();

            int total = cleanedTasks.Count;
            if (total == 0) return null;

            int easy = cleanedTasks.Count(t => t.Difficulty == 1);
            int medium = cleanedTasks.Count(t => t.Difficulty == 2);
            int hard = cleanedTasks.Count(t => t.Difficulty == 3);

            double est = cleanedTasks.Sum(t => t.EstimatedTime);
            double act = cleanedTasks.Sum(t => t.ActualTime);

            var completed = cleanedTasks.Where(t => t.Status == 5).ToList();

            double completionRate = completed.Count / (double)total;
            double efficiency = act == 0 ? 0 : est / act;
            double avgEval = completed.Any() ? completed.Average(t => t.EvaluationScore) : 0;

            return new UserTasks
            {
                Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name,
                EasyTaskCount = easy,
                MediumTaskCount = medium,
                HardTaskCount = hard,
                TotalEstimatedHours = Math.Round(est, 2),
                TotalActualHours = Math.Round(act, 2),
                CompletionRate = Math.Round(completionRate, 2),
                AverageEfficiency = Math.Round(efficiency, 2),
                CompletedTaskCount = completed.Count,
                TotalTaskCount = total,
                TaskCompletionRatio = Math.Round(completionRate, 2),
                AverageTaskEvaluation = Math.Round(avgEval, 2),
                Label = "" 
            };
        }
    }
}
