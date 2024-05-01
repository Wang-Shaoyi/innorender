using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.IO;
using System.Text.Json;
using Rhino;

namespace InnoRender.Uploader
{
    internal class ImageUploader
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ImageUploader(string apiUrl)
        {
            _httpClient = new HttpClient();
            _apiUrl = apiUrl;
        }

        public async Task<string> UploadImageAsync(string filePath, string apiKey)
        {
            try
            {
                var url = $"{_apiUrl}/api/upload/";
                using (var multipartContent = new MultipartFormDataContent())
                {
                    // 添加文件
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                    multipartContent.Add(fileContent, "uploadedFile", "demo.jpg");

                    // 添加其他表单数据
                    multipartContent.Add(new StringContent(apiKey), "api_token");
                    multipartContent.Add(new StringContent("3"), "mode");
                    multipartContent.Add(new StringContent("Trial"), "uploadPath");
                    multipartContent.Add(new StringContent("0"), "watermark");

                    // 发送 POST 请求
                    var response = await _httpClient.PostAsync(url, multipartContent);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // 解析响应并返回图片 URL
                    var responseData = JsonDocument.Parse(responseBody);
                    var imageUrl = responseData.RootElement.GetProperty("url").GetString();
                    return imageUrl;
                }
            }
            catch (Exception ex)
            {
                RhinoApp.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
