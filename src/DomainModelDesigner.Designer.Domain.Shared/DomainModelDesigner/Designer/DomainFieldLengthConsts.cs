﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModelDesigner.Designer
{
    public class DomainFieldLengthConsts
    {
        public class AppConsts
        {
            public const int AppNameLen = 20;

            public const int DomainNameLen = 20;

            public const int DomainRemarkLen = 255;
        }

        public class ValueObjectConsts
        {
            public const int ValueObjectNameLen = 50;

            public const int ValueObjectDescriptionLen = 255;

            public const int ValueObjectFieldNameLen = 20;

            public const int ValueObjectFieldTypeIdLen = 36;

            public const int ValueObjectFieldLenLen = 10;

            public const int ValueObjectFieldDescriptionLen = 255;
        }

        public class IndexConsts
        {
            public const int Index_Fields_Len = 100;

            public const int Index_Len = 30;
        }

        public class FieldConsts
        {
            public const int FieldTypeMaxLen = 36;

            public const int NameMaxLen = 20;

            public const int FieldLenMaxLen = 10;

            public const int FieldDescMaxLen = 255;
        }
    }
}
