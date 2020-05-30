using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DevFramework.Nort.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
    public class DataBaseLogger : LoggerService
    {
        public DataBaseLogger() : base(LogManager.GetLogger("DatabaseLogger"))
        {
        }
    }
}
