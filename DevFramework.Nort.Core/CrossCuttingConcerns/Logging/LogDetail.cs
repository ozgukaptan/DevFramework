using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Nort.Core.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}
