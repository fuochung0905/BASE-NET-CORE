using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.K_MEAN.Dtos
{
    public class UserTasks
    {
        public string Name { get; set; }
        public int EasyTaskCount { get; set; }
        public int MediumTaskCount { get; set; }
        public int HardTaskCount { get; set; }
        public double TotalEstimatedHours { get; set; }
        public double TotalActualHours { get; set; }
        public double CompletionRate { get; set; }
        public double AverageEfficiency { get; set; }
        public int CompletedTaskCount { get; set; }
        public int TotalTaskCount { get; set; }
        public double TaskCompletionRatio { get; set; }
        public double AverageTaskEvaluation { get; set; }

        public string Label { get; set; }

    }
}
