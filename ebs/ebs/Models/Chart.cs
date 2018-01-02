using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ebs.Models
{
    public class Chart
    {
        public List<string> labels { get; set; }
        public List<Datasets> datasets { get; set; }
    }
    public class Datasets
    {
        public string label { get; set; }
        public List<string> backgroundColor { get; set; }
        public List<string> borderColor { get; set; }
        public List<string> borderWidth { get; set; }
        public List<float> data { get; set; }
    }
}