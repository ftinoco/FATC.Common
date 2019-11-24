using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FATC.Common.WebUseful
{
    public class BaseWebApiResult
    {
        public BaseWebApiResult()
        {
            Message = " ";
            ResponseCode = HttpStatusCode.OK;
        }

        [JsonProperty(PropertyName = "message")]
        /// <summary>
        /// Mensaje de respuesta de la petición
        /// </summary>
        public string Message { get; set; }

        [JsonProperty(PropertyName = "responseCode")]
        /// <summary>
        /// Código de respuesta de la petición
        /// </summary>
        public HttpStatusCode ResponseCode { set; get; }
    }

}
