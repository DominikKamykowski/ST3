using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace SzkolenieTechniczne3.Common.CrossCutting.Interfaces
{
    public interface IApiHttpException
    {
        public uint HttpErrorCode { get; }
        public JsonObject Error { get; }
    }
}
