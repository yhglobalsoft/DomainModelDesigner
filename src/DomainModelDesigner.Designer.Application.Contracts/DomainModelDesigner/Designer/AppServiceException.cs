﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Volo.Abp;

namespace DomainModelDesigner.Designer
{
    public class AppServiceException : BusinessException
    {
        public AppServiceException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context)
        {
        }

        public AppServiceException(string code = null, string message = null, string details = null, Exception innerException = null, LogLevel logLevel = LogLevel.Warning)
           : base(code, message,details,innerException, logLevel)
        {

        }
    }
}
