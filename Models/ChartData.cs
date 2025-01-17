using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Models
{
    public class ChartData
    {
        public List<ChartSeriesModel> Series { get; set; }
        public string[] XAxisLabels { get; set; }
    }

    public class ChartSeriesModel
    {
        public string Name { get; set; }
        public double[] Data { get; set; }
    }
}
