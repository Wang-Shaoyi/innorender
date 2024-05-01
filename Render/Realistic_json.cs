using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Rhino;

namespace InnoRender.Render
{
    internal class Realistic_json
    {
        // C# classes from json via https://json2csharp.com/
        public class _15
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _19
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _3
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _31
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _38
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _4
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _41
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _44
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _45
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _47
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _6
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _7
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class _8
        {
            public Inputs inputs { get; set; }
            public string class_type { get; set; }
            public Meta _meta { get; set; }
        }

        public class Inputs
        {
            public long seed { get; set; }
            public int steps { get; set; }
            public double cfg { get; set; }
            public string sampler_name { get; set; }
            public string scheduler { get; set; }
            public int denoise { get; set; }
            public List<object> model { get; set; }
            public List<object> positive { get; set; }
            public List<object> negative { get; set; }
            public List<object> latent_image { get; set; }
            public string filename_prefix { get; set; }
            public List<object> images { get; set; }
            public string image_path { get; set; }
            public string RGBA { get; set; }
            public string filename_text_extension { get; set; }
            public List<object> image { get; set; }
            public List<object> width { get; set; }
            public List<object> height { get; set; }
            public int batch_size { get; set; }
            public string ckpt_name { get; set; }
            public string text { get; set; }
            public List<object> clip { get; set; }
            public List<object> samples { get; set; }
            public List<object> vae { get; set; }
            public string lora_name { get; set; }
            public int strength_model { get; set; }
            public int strength_clip { get; set; }
            public string control_net_name { get; set; }
            public int strength { get; set; }
            public int start_percent { get; set; }
            public double end_percent { get; set; }
            public List<object> control_net { get; set; }
            public string coarse { get; set; }
            public int resolution { get; set; }
        }

        public class Meta
        {
            public string title { get; set; }
        }

        public class Root_Realistic
        {
            [JsonPropertyName("3")]
            public _3 _3 { get; set; }

            [JsonPropertyName("4")]
            public _4 _4 { get; set; }

            [JsonPropertyName("6")]
            public _6 _6 { get; set; }

            [JsonPropertyName("7")]
            public _7 _7 { get; set; }

            [JsonPropertyName("8")]
            public _8 _8 { get; set; }

            [JsonPropertyName("15")]
            public _15 _15 { get; set; }

            [JsonPropertyName("19")]
            public _19 _19 { get; set; }

            [JsonPropertyName("31")]
            public _31 _31 { get; set; }

            [JsonPropertyName("38")]
            public _38 _38 { get; set; }

            [JsonPropertyName("41")]
            public _41 _41 { get; set; }

            [JsonPropertyName("44")]
            public _44 _44 { get; set; }

            [JsonPropertyName("45")]
            public _45 _45 { get; set; }

            [JsonPropertyName("47")]
            public _47 _47 { get; set; }
        }


        //turn json string to C#
        public class JsonParser
        {
            public static Root_Realistic ParseJson(string jsonString)
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<Root_Realistic>(jsonString, options);
                }
                catch (Exception ex)
                {
                    RhinoApp.WriteLine($"An error occurred: {ex}");
                    return null;
                }
            }
        }

        //change some parameters
        public class JsonChangeElement_Realistic
        {
            private Root_Realistic myPrompt;

            public Root_Realistic Json_Realistic(string image_url, string positive_prompt)
            {
                string jsonString_realistic = File.ReadAllText("realistic.json");
                myPrompt = JsonParser.ParseJson(jsonString_realistic);

                myPrompt._6.inputs.text = positive_prompt;
                myPrompt._44.inputs.image_path = image_url;

                string json_test = JsonSerializer.Serialize(myPrompt);
                return myPrompt;
            }
        }
    }
}
