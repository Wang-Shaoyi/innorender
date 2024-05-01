using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Rhino;

namespace InnoRender
{
    internal class API_handle
    {
        public class AppSettings
        {
            [JsonPropertyName("ApiKeys")]
            public ApiKeys ApiKeys { get; set; }

            [JsonPropertyName("urls")]
            public Urls Urls { get; set; }

            [JsonPropertyName("others")]
            public Others Others { get; set; }
        }

        public class ApiKeys
        {
            [JsonPropertyName("Server")]
            public string Server { get; set; }
            [JsonPropertyName("Workflow")]
            public string Workflow { get; set; }
            [JsonPropertyName("GPT")]
            public string GPT { get; set; }
        }

        public class Urls
        {
            [JsonPropertyName("Server")]
            public string Server { get; set; }
        }

        public class Others
        {
            [JsonPropertyName("workflowID")]
            public string WorkflowID { get; set; }
        }
    }
}
