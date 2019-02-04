using CustomDateTimeModelBinding.Core.Converters;
using Newtonsoft.Json;
using System;

namespace CustomDateTimeModelBinding.Core.Model
{
    public class PostData
    {
        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "MM-dd-yyyy" })]
        public DateTime DateFrom { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter), new object[] { "MM-dd-yyyy" })]
        public DateTime? DateTo { get; set; }
    }
}
