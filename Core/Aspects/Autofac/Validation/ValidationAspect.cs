using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {
        Type _validatorType;

        public ValidationAspect(Type validationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validationType))
            {
                throw new Exception("bu çalışabilir bir attribute değil"); 
            }
            _validatorType = validationType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator= (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(p => p.GetType() == entityType);

            foreach (var item in entities)
            {
                ValidationTool.Validate(validator, item);
            }
        }
    }
}
