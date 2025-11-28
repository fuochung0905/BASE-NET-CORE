using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.KNN.Dtos
{
    public class TaskRecord
    {
        public int Difficulty { get; set; }        
        public double EstimatedTime { get; set; }
        public double ActualTime { get; set; }
        public int Status { get; set; }           
        public int EvaluationScore { get; set; }
    }
}
