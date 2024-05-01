using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Rhino;
using static InnoRender.Render.StyleTransfer_json;

namespace InnoRender.Render
{
    internal class StyleTransfer_json
    {
        // C# classes from json via https://json2csharp.com/
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class _1
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _10
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _2
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _22
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _3
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _4
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _5
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _6
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _7
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _71
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _72
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _73
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _75
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _76
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _77
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _8
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _81
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _82
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _84
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _85
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _93
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _94
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class _96
        {
            [JsonPropertyName("inputs")]
            public Inputs inputs { get; set; }

            [JsonPropertyName("class_type")]
            public string class_type { get; set; }

            [JsonPropertyName("_meta")]
            public Meta _meta { get; set; }
        }

        public class Inputs
        {
            [JsonPropertyName("ckpt_name")]
            public string ckpt_name { get; set; }

            [JsonPropertyName("width")]
            public List<object> width { get; set; }

            [JsonPropertyName("height")]
            public List<object> height { get; set; }

            [JsonPropertyName("batch_size")]
            public int batch_size { get; set; }

            [JsonPropertyName("preprocessor")]
            public string preprocessor { get; set; }

            [JsonPropertyName("resolution")]
            public int resolution { get; set; }

            [JsonPropertyName("image")]
            public List<object> image { get; set; }

            [JsonPropertyName("strength")]
            public double strength { get; set; }

            [JsonPropertyName("start_percent")]
            public int start_percent { get; set; }

            [JsonPropertyName("end_percent")]
            public int end_percent { get; set; }

            [JsonPropertyName("positive")]
            public List<object> positive { get; set; }

            [JsonPropertyName("negative")]
            public List<object> negative { get; set; }

            [JsonPropertyName("control_net")]
            public List<object> control_net { get; set; }

            [JsonPropertyName("control_net_name")]
            public string control_net_name { get; set; }

            [JsonPropertyName("ipadapter_file")]
            public string ipadapter_file { get; set; }

            [JsonPropertyName("clip_name")]
            public string clip_name { get; set; }

            [JsonPropertyName("interpolation")]
            public string interpolation { get; set; }

            [JsonPropertyName("crop_position")]
            public string crop_position { get; set; }

            [JsonPropertyName("sharpening")]
            public double sharpening { get; set; }

            [JsonPropertyName("seed")]
            public int seed { get; set; }

            [JsonPropertyName("steps")]
            public int steps { get; set; }

            [JsonPropertyName("cfg")]
            public double cfg { get; set; }

            [JsonPropertyName("sampler_name")]
            public string sampler_name { get; set; }

            [JsonPropertyName("scheduler")]
            public string scheduler { get; set; }

            [JsonPropertyName("denoise")]
            public int denoise { get; set; }

            [JsonPropertyName("model")]
            public List<object> model { get; set; }

            [JsonPropertyName("latent_image")]
            public List<object> latent_image { get; set; }

            [JsonPropertyName("weight")]
            public int weight { get; set; }

            [JsonPropertyName("weight_type")]
            public string weight_type { get; set; }

            [JsonPropertyName("combine_embeds")]
            public string combine_embeds { get; set; }

            [JsonPropertyName("start_at")]
            public int start_at { get; set; }

            [JsonPropertyName("end_at")]
            public int end_at { get; set; }

            [JsonPropertyName("embeds_scaling")]
            public string embeds_scaling { get; set; }

            [JsonPropertyName("ipadapter")]
            public List<object> ipadapter { get; set; }

            [JsonPropertyName("clip_vision")]
            public List<object> clip_vision { get; set; }

            [JsonPropertyName("image_path")]
            public string image_path { get; set; }

            [JsonPropertyName("RGBA")]
            public string RGBA { get; set; }

            [JsonPropertyName("filename_text_extension")]
            public string filename_text_extension { get; set; }

            [JsonPropertyName("text")]
            public string text { get; set; }

            [JsonPropertyName("clip")]
            public List<object> clip { get; set; }

            [JsonPropertyName("vae_name")]
            public string vae_name { get; set; }

            [JsonPropertyName("samples")]
            public List<object> samples { get; set; }

            [JsonPropertyName("vae")]
            public List<object> vae { get; set; }

            [JsonPropertyName("lora_name")]
            public string lora_name { get; set; }

            [JsonPropertyName("strength_model")]
            public int strength_model { get; set; }

            [JsonPropertyName("strength_clip")]
            public int strength_clip { get; set; }

            [JsonPropertyName("sampling")]
            public string sampling { get; set; }

            [JsonPropertyName("zsnr")]
            public bool zsnr { get; set; }

            [JsonPropertyName("filename_prefix")]
            public string filename_prefix { get; set; }

            [JsonPropertyName("images")]
            public List<object> images { get; set; }
        }

        public class Meta
        {
            [JsonPropertyName("title")]
            public string title { get; set; }
        }

        public class Root_StyleTransfer
        {
            [JsonPropertyName("1")]
            public _1 _1 { get; set; }

            [JsonPropertyName("2")]
            public _2 _2 { get; set; }

            [JsonPropertyName("3")]
            public _3 _3 { get; set; }

            [JsonPropertyName("4")]
            public _4 _4 { get; set; }

            [JsonPropertyName("5")]
            public _5 _5 { get; set; }

            [JsonPropertyName("6")]
            public _6 _6 { get; set; }

            [JsonPropertyName("7")]
            public _7 _7 { get; set; }

            [JsonPropertyName("8")]
            public _8 _8 { get; set; }

            [JsonPropertyName("10")]
            public _10 _10 { get; set; }

            [JsonPropertyName("22")]
            public _22 _22 { get; set; }

            [JsonPropertyName("71")]
            public _71 _71 { get; set; }

            [JsonPropertyName("72")]
            public _72 _72 { get; set; }

            [JsonPropertyName("73")]
            public _73 _73 { get; set; }

            [JsonPropertyName("75")]
            public _75 _75 { get; set; }

            [JsonPropertyName("76")]
            public _76 _76 { get; set; }

            [JsonPropertyName("77")]
            public _77 _77 { get; set; }

            [JsonPropertyName("81")]
            public _81 _81 { get; set; }

            [JsonPropertyName("82")]
            public _82 _82 { get; set; }

            [JsonPropertyName("84")]
            public _84 _84 { get; set; }

            [JsonPropertyName("85")]
            public _85 _85 { get; set; }

            [JsonPropertyName("93")]
            public _93 _93 { get; set; }

            [JsonPropertyName("94")]
            public _94 _94 { get; set; }

            [JsonPropertyName("96")]
            public _96 _96 { get; set; }
        }



        //turn json string to C#
        public class JsonParser
        {
            public static Root_StyleTransfer ParseJson(string jsonString)
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    return JsonSerializer.Deserialize<Root_StyleTransfer>(jsonString, options);
                }
                catch (Exception ex)
                {
                    RhinoApp.WriteLine($"An error occurred: {ex}");
                    return null;
                }
            }
        }

        //change some parameters
        public class JsonChangeElement_StyleTransfer
        {
            private Root_StyleTransfer myPrompt;

            public Root_StyleTransfer Json__StyleTransfer(string image_url, string style_url, string positive_prompt)
            {
                string jsonString__StyleTransfer = File.ReadAllText("styleTransfer2.json");
                myPrompt = JsonParser.ParseJson(jsonString__StyleTransfer);

                myPrompt._3.inputs.text = positive_prompt;
                myPrompt._96.inputs.image_path = style_url;
                myPrompt._94.inputs.image_path = image_url;

                string json_test = JsonSerializer.Serialize(myPrompt);
                return myPrompt;
            }
        }
    }
}
