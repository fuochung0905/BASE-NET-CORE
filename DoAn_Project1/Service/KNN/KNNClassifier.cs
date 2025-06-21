using MODELS.K_MEAN.Dtos;
using MODELS.KNN.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.KNN
{
    public static class KNNClassifier
    {

        public static string Classify(UserTasks input, List<UserTasks> trainingSet, int k = 3)
        {
            var distances = trainingSet
                .Select(s => new
                {
                    Label = s.Label,
                    Distance = Math.Sqrt(
                        Math.Pow(input.EasyTaskCount - s.EasyTaskCount, 2) +
                        Math.Pow(input.MediumTaskCount - s.MediumTaskCount, 2) +
                        Math.Pow(input.HardTaskCount - s.HardTaskCount, 2) +
                        Math.Pow(input.TotalEstimatedHours - s.TotalEstimatedHours, 2) +
                        Math.Pow(input.TotalActualHours - s.TotalActualHours, 2) +
                        Math.Pow(input.CompletionRate - s.CompletionRate, 2) +
                        Math.Pow(input.AverageEfficiency - s.AverageEfficiency, 2)
                    )
                })
                .OrderBy(x => x.Distance)
                .Take(k)
                .GroupBy(x => x.Label)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            return distances?.Key ?? "Không rõ";
        }

        public static List<UserTasks> ClassifyClass( Dictionary<string, List<TaskRecord>> classTaskDict,  List<UserTasks> trainingSet, int k = 3)
        {
            var results = new List<UserTasks>();

            foreach (var entry in classTaskDict)
            {
                var student = ConvertToUser.ConvertToStudent(entry.Key, entry.Value);
                if (student != null)
                {
                    student.Label = KNNClassifier.Classify(student, trainingSet, k);
                    results.Add(student);
                }
            }

            return results;
        }

    }

}
