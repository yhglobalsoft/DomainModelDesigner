//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Volo.Abp.Application.Services;
//using Volo.Abp.DependencyInjection;
//using Volo.Abp.DynamicProxy;

//namespace DomainModelDesigner.Designer.Dtos.Interceptors
//{
//    /// <summary>
//    /// 验证Dto的参数
//    /// </summary>
//    public class DtoValidationInterceptor : AbpInterceptor, ITransientDependency
//    {
//        public override void Intercept(IAbpMethodInvocation invocation)
//        {
//            var type = invocation.GetType();

//            if (typeof(IApplicationService).IsAssignableFrom(type))
//            {

//            }
//        }
//    }
//}
