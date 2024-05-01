using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using static InnoRender.Render.Realistic_json;
using static InnoRender.Render.StyleTransfer_json;

namespace InnoRender.Render
{
    internal class JsonRequest
    {
        private readonly HttpClient _httpClient;

        public JsonRequest()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> RunWorkflowAsync(string workflowId, string description,string style_url, string image_url, string api, bool style)//style strue: style transfer
        {
            var apiKey = api;
            
            var files = new 
            {
                InputImagePath = image_url
            };

            string json = null;

            //Get parameters (string) from json file, and turn it to the format of C# class
            if (style)
            {
                JsonChangeElement_StyleTransfer json_R = new JsonChangeElement_StyleTransfer();
                Root_StyleTransfer Prompt = json_R.Json__StyleTransfer(image_url, style_url, description);

                var body = new
                {
                    prompt = Prompt,
                    files = files
                };
                json = JsonSerializer.Serialize(body);
            }
            else
            {
                JsonChangeElement_Realistic json_R = new JsonChangeElement_Realistic();
                Root_Realistic Prompt = json_R.Json_Realistic(image_url, description);
                var body = new
                {
                    prompt = Prompt,
                    files = files
                };
                json = JsonSerializer.Serialize(body);
            }
            


            //construct and send api call
            var requestBody = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            string url = $"https://comfy.icu/api/v1/workflows/{workflowId}/runs";
            HttpResponseMessage response = await _httpClient.PostAsync(url, requestBody);
            var responseJson = await response.Content.ReadAsStringAsync();


            //get runID from api call
            using (JsonDocument doc = JsonDocument.Parse(responseJson))
            {
                JsonElement root = doc.RootElement;
                string run_ID = root.GetProperty("id").GetString();
                return run_ID;
            }
        }
    }
}
