using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Rhino;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InnoRender.Prompt
{
    internal class PromptfromGPT
    {
        private readonly HttpClient _httpClient;
        public PromptfromGPT()
        {
            _httpClient = new HttpClient();
        }


        public async Task<string> GetAIResponse(string yourPrompt, string gpt_api)
        {
            var apiKey = gpt_api;

            // Create a data object to be serialized
            var data = new
            {
                model = "gpt-4",
                messages = new List<object>
            {
                new { role = "system", content = "You are an assistant skilled in providing prompts for image-to-image generation. " +
                "I give you some requirements for generating an architectural rendering, and you help me organize them into a prompt for image-to-image generation. " +
                "Give me only the prompt without anything else." },
                new { role = "user", content = yourPrompt }
            },
                max_tokens = 50,
                temperature = 0.4,

            };

            // Serialize data object to JSON string
            var json = JsonSerializer.Serialize(data);
            var requestBody = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestBody);
            var responseString = await response.Content.ReadAsStringAsync();

            using (JsonDocument doc = JsonDocument.Parse(responseString))
            {
                JsonElement root = doc.RootElement;
                string content = root.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                return content;
            }
        }
    }
}
