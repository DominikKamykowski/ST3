using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Common.CrossCutting.Interfaces;

namespace SzkolenieTechniczne3.Common.CrossCutting.Exceptions
{
    public class ApiHttpException : Exception, IApiHttpException
    {
        public uint HttpErrorCode { get; private set; }
        public JsonObject Error { get; private set; }

        public ApiHttpException(uint httpErrorCode, JsonObject error = null)
        {
            HttpErrorCode = httpErrorCode;
            Error = error;
        }
    }
}
