using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CobroSmart.Domain.Builder
{
    public class ResponseBuild
    {
        private BaseResponse _response = new BaseResponse();

        public ResponseBuild SetSuccess(bool succes)
        {
            _response.Success = succes;
            return this;
        }

        public ResponseBuild SetMessage(string message)
        {
            _response.Message = message;
            return this;
        }

        public ResponseBuild SetData(object data)
        {
            _response.Data = data;
            return this;
        }

        public ResponseBuild SetStatus(HttpStatusCode status)
        {
            _response.StatusCode = status;
            return this;
        }

        public BaseResponse Build()
        {
            return _response;
        }
    }
}
