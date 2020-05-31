using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Core.CrossCuttingConcerns.Logging;
using DevFramework.Nort.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramework.Nort.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    // Aspectin clasın başına yazılması durumunda constrac metod hariç diğer metodlarda çalışması için. yazıyoruz.
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        //bir instance üretmek için kullanıyoruz
        public override void RuntimeInitialize(MethodBase method)
        {

            if (_loggerType.BaseType != typeof(LoggerService))
            {
                throw new Exception("wrong logger type");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return; ;
            }

            try
            {
                var logParaMeters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParaMeters
                };

                _loggerService.Info(logDetail);
                _loggerService.Error(logDetail);
                
            }
            catch (Exception)
            {

            }
        }
    }
}
