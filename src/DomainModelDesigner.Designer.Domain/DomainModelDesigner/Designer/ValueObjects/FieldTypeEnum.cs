using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer.ValueObjects
{
    /// <summary>
    /// 字段类型
    /// </summary>
    public class FieldTypeEnum: Enumeration
    {
        public static FieldTypeEnum INT = new FieldTypeEnum(1,nameof(INT));
        public static FieldTypeEnum STRING = new FieldTypeEnum(2, nameof(STRING));
        public static FieldTypeEnum DECIMAL = new FieldTypeEnum(3, nameof(DECIMAL));
        public static FieldTypeEnum DATETIME = new FieldTypeEnum(4, nameof(DATETIME));
        public static FieldTypeEnum BOOL = new FieldTypeEnum(5, nameof(BOOL));
        public static FieldTypeEnum UUID = new FieldTypeEnum(5, nameof(UUID));

        public FieldTypeEnum(int id, string name):base(id,name)
        {
        }

        public static FieldTypeEnum GetById(int id)
        {
            IEnumerable<FieldTypeEnum> list = GetAll<FieldTypeEnum>();
            var obj = list.GetEnumerator();
            while (obj.MoveNext())
            {
                if (obj.Current.Id == id)
                    return obj.Current;
            }

            return null;
        }
    }
}
