using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Nort.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;

namespace DevFramework.Nort.Core.Aspects.Postsharp
{
    [Serializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validadorType;

        public FluentValidationAspect(Type validadorType)
        {
            _validadorType = validadorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator) Activator.CreateInstance(_validadorType);
            var entityType = _validadorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FuluentValidate(validator,entity);
            }
        }
    }
}
