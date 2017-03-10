using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TryToBuildBot
{
    public class Response<T>
    {
        [JsonProperty(PropertyName = "ok", Required = Required.Always)]
        public bool Success { get; set; }
        [JsonProperty(PropertyName = "result", Required = Required.Default)]
        public T Result { get; set; }

    }
}
