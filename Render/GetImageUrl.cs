using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.CSharp;


namespace InnoRender.Render
{
    internal class GetImageUrl
    {
        private readonly HttpClient _httpClient;

        public GetImageUrl()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetFinalUrl(string workflowId, string runId, string apiKey)
        {
            string url = $"https://comfy.icu/api/v1/workflows/{workflowId}/runs/{runId}";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            RhinoApp.WriteLine("Start processing. Please wait. You can do your own stuff. Your browser will pop up when finished.");
            
            string previousStatus = "WAIT";

            while (true)
            {
                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(url);
                    var result = await response.Content.ReadAsStringAsync();

                    using (JsonDocument doc = JsonDocument.Parse(result))
                    {
                        JsonElement root = doc.RootElement;
                        string currentStatus = root.GetProperty("status").GetString();

                        if (currentStatus != previousStatus)
                        {
                            RhinoApp.WriteLine($"Status changed to: {currentStatus}");
                            previousStatus = currentStatus;

                            if (currentStatus == "COMPLETED" || currentStatus == "ERROR")
                            {
                                return currentStatus;
                            }
                        }

                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return "ERROR"; 
                }
            }
        }
    }
}
