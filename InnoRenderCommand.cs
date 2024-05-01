using Rhino;
using Rhino.Commands;
using System;


using InnoRender.Capture;
using System.Threading.Tasks;

using InnoRender.Uploader;
using InnoRender.Render;

using InnoRender.ImageGet;
using InnoRender.Prompt;
using System.IO;
using System.Text.Json;

using static InnoRender.API_handle;

namespace InnoRender
{
    public class InnoRenderCommand : Command
    {
        private bool _interrupted = false;
        public InnoRenderCommand()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
            RhinoApp.EscapeKeyPressed += OnEscapeKeyPressed;
        }

        ///<summary>The only instance of this command.</summary>
        public static InnoRenderCommand Instance { get; private set; }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName => "InnoRenderCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // TODO: start here modifying the behaviour of your command.
            // ---

            //Capture current view (!!Will need input from Webapp)
            _interrupted = false;

            ViewCaptureInno capture = new ViewCaptureInno();
            string capturedFilePath = capture.CaptureAndView();
            RhinoApp.WriteLine("Successfully captured current view.");

            //Check interruption
            if (_interrupted)
            {
                RhinoApp.WriteLine("Operation was interrupted by the user.");
                return Result.Cancel;
            }

            //get mode and upload style image (!!Will need input from Webapp)
            GetMode style_bool = new GetMode();
            bool style = style_bool.GetModeFromUser();

            string stylePath = null;
            if (style)
            {
                RhinoApp.WriteLine("Please select your style image");
                GetStyleImage style_path = new GetStyleImage();
                stylePath = style_path.SelectImage();
            }

            //Check interruption 2
            if (_interrupted)
            {
                RhinoApp.WriteLine("Operation was interrupted by the user.");
                return Result.Cancel;
            }

            //Get setting options (!!Will need input from Webapp)
            GetPromptOption userOption = new GetPromptOption();
            string settings = userOption.settings();
            RhinoApp.WriteLine("Your settings are: " + settings);

            //Check interruption 3
            if (_interrupted)
            {
                RhinoApp.WriteLine("Operation was interrupted by the user.");
                return Result.Cancel;
            }

            //Get API key
            string fileName = "appsettings.json";
            string jsonString = File.ReadAllText(fileName);
            AppSettings Config = JsonSerializer.Deserialize<AppSettings>(jsonString);

            string apiKey_server = Config.ApiKeys.Server;
            string apiKey_workflow = Config.ApiKeys.Workflow;
            string apiKey_GPT = Config.ApiKeys.GPT;
            string apiUrl_server = Config.Urls.Server;
            string workflowID = Config.Others.WorkflowID;


            //Create everything I need for async upload
            ImageUploader uploader_screenshot = new ImageUploader(apiUrl_server);
            ImageUploader style_image = new ImageUploader(apiUrl_server);
            PromptfromGPT Prompt = new PromptfromGPT();
            JsonRequest request = new JsonRequest();
            GetImageUrl run_status = new GetImageUrl();

            //Do async upload to online server if screenshot is successful
            if (!string.IsNullOrEmpty(capturedFilePath))
            {
                Task.Run(async () =>
                {
                    try
                    {
                        //upload images to online server

                        string imageUrl = await uploader_screenshot.UploadImageAsync(capturedFilePath, apiKey_server);
                        string imageUrl_style = await uploader_screenshot.UploadImageAsync(stylePath, apiKey_server);

                        RhinoApp.WriteLine($"Image was uploaded successfully: {imageUrl}");


                        //Delete image after upload
                        if (System.IO.File.Exists(capturedFilePath))
                        {
                            System.IO.File.Delete(capturedFilePath);
                        }
                        else
                        {
                            RhinoApp.WriteLine("File not found: " + capturedFilePath);
                        }

                        //Check interruption 4
                        if (_interrupted)
                        {
                            RhinoApp.WriteLine("Operation was interrupted by the user.");
                            return;
                        }

                        //Get Prompt
                        string prompt = await Prompt.GetAIResponse(settings, apiKey_GPT);
                        RhinoApp.WriteLine($"Your prompt is: {prompt}");

                        //Check interruption 5
                        if (_interrupted)
                        {
                            RhinoApp.WriteLine("Operation was interrupted by the user.");
                            return;
                        }

                        // Set up workflow and Get run ID
                        string RunID = await request.RunWorkflowAsync(workflowID, prompt, imageUrl_style, imageUrl, apiKey_workflow, style);
                        RhinoApp.WriteLine($"Your RunID is: {RunID}");

                        //Show status and get returned url
                        string status = await run_status.GetFinalUrl(workflowID, RunID, apiKey_workflow);
                        if (status == "COMPLETED")
                        {
                            string return_url = $"https://r2.comfy.icu/workflows/{workflowID}/output/{RunID}/ComfyUI_00001_.png";
                            RhinoApp.WriteLine("Workflow completed. Output URL: " + return_url); //(!!Will output to WebApp)

                            //Show rendered image (!!Will output to WebApp)
                            OpenWebWindow webWindow = new OpenWebWindow();
                            webWindow.OpenUrl(return_url);
                        }
                        else
                        {
                            RhinoApp.WriteLine("Workflow failed");
                        }
                    }
                    catch (Exception ex)
                    {
                        RhinoApp.WriteLine("InnoRender failed :(, the reason is: " + ex.Message);
                    }
                });
            }
            else
            {
                RhinoApp.WriteLine("View capture failed.");
            }

            // ---
            return Result.Success;
        }
        private void OnEscapeKeyPressed(object sender, EventArgs e)
        {
            _interrupted = true; 
        }
    }
}
