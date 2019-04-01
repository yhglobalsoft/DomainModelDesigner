using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace DomainModelDesigner.Designer.Tools
{
    public interface ICheck
    {
        ICheck IsNull<T>(T obj) where T:class;

        ICheck IsNull<T>(List<T> list) where T : class;

        ICheck IsNullForEach<T>(List<T> list, Action<T> action) where T : class;

        ICheck IsNullOrWhiteSpace(string value, string paramName);

        ICheck IsTooLong(int maxLen, string value, string paramName);

        ICheck GuidIsNull(Guid value);
    }
}
