using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FATC.Common.WebUseful
{
    public class WebApiResult<TData> : BaseWebApiResult
    {
        public WebApiResult() : base()
        {
        }

        public WebApiResult(TData data) : base()
        {
            Data = data;
        }


        [JsonProperty(PropertyName = "data")]
        /// <summary>
        /// Datos de la petición
        /// </summary>
        public TData Data { get; set; }
    }
}
