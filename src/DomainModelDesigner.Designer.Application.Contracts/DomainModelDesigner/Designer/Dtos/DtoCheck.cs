using DomainModelDesigner.Designer.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace DomainModelDesigner.Designer.Dtos
{
    public class DtoCheck : ICheck, ISingletonDependency
    {
        public ICheck GuidIsNull(Guid value)
        {
            if (value.Equals(Guid.Empty))
                throw new AppServiceException(DesignerDomainErrorCodes.NullOrEmptyCheck).WithData("paramName", nameof(value));

            return this;
        }

        public ICheck IsNull<T>(T obj) where T : class
        {
            if (obj == null)
                throw new AppServiceException(DesignerDomainErrorCodes.NullOrEmptyCheck).WithData("paramName", nameof(obj));

            return this;
        }

        public ICheck IsNull<T>(List<T> list) where T : class
        {
            if (list == null)
                throw new AppServiceException(DesignerDomainErrorCodes.NullOrEmptyCheck).WithData("paramName", nameof(list));

            if (list.Count < 1)
                throw new AppServiceException(DesignerDomainErrorCodes.NullOrEmptyCheck).WithData("paramName", nameof(list));

            return this;
        }

        public ICheck IsNullForEach<T>(List<T> list, Action<T> action) where T : class
        {
            IsNull(list);

            list.ForEach(p =>
            {
                action(p);
            }
            );

            return this;
        }

        public ICheck IsNullOrWhiteSpace(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new AppServiceException(DesignerDomainErrorCodes.NullOrEmptyCheck).WithData("paramName", paramName);

            return this;
        }

        public ICheck IsTooLong(int maxLen, string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                return this;

            if (value.Length > maxLen)
                throw new AppServiceException(DesignerDomainErrorCodes.IsTooLongCheck)
                    .WithData("paramName", paramName)
                    .WithData("len", maxLen);

            return this;
        }
    }
}
