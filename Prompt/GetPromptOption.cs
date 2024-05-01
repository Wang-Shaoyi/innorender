using Rhino.Commands;
using Rhino.Input.Custom;
using Rhino.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Rhino;
using Rhino.UI;

namespace InnoRender.Prompt
{
    internal class GetPromptOption
    {

        public string GetWeatherFromUser()
        {
            GetOption go = new GetOption();
            go.SetCommandPrompt("Choose your weather settings (Default: Sunny)");

            // Selections
            go.AddOption("Sunny");
            go.AddOption("Rainy");
            go.AddOption("Cloudy");
            go.AddOption("Snowy");
            go.AddOption("Windy");

            // Get input
            if (go.Get() == GetResult.Option)
            {
                var option = go.Option();
                if (option != null)
                {
                    RhinoApp.WriteLine(option.EnglishName);
                    return option.EnglishName;
                }
            }
            return "Sunny";
        }

        public string GetEnvironmentFromUser()
        {
            GetOption go = new GetOption();
            go.SetCommandPrompt("Choose your environmental settings (Default: City)");

            // Selections
            go.AddOption("City");
            go.AddOption("Rural");
            go.AddOption("Grassland");
            go.AddOption("Snowland");
            go.AddOption("Mars");

            // Get input
            if (go.Get() == GetResult.Option)
            {
                var option = go.Option();
                if (option != null)
                {
                    RhinoApp.WriteLine(option.EnglishName);
                    return option.EnglishName;
                }
            }
            return "City";
        }

        public string GetTimeFromUser()
        {
            GetOption go = new GetOption();
            go.SetCommandPrompt("Choose your time settings (Default: Morning)");

            // Selections
            go.AddOption("Morning");
            go.AddOption("Noon");
            go.AddOption("Evening");
            go.AddOption("Night");
            go.AddOption("Sunset");

            // Get input
            if (go.Get() == GetResult.Option)
            {
                var option = go.Option();
                if (option != null)
                {
                    RhinoApp.WriteLine(option.EnglishName);
                    return option.EnglishName;
                }
            }
            return "Morning";
        }

        public string GetTextFromUser()
        {

            GetString text = new GetString();
            text.AcceptString(true);
            text.SetCommandPrompt("Please enter your prompt. Press enter when finish. (Press esc to quit if you don't want to process)");


            GetResult result = text.GetLiteralString();

            if (result == GetResult.String)  
            {
                string userInput = text.StringResult();  
                RhinoApp.WriteLine("You entered: " + userInput);
                return userInput;
            }
            else
            {
                RhinoApp.WriteLine("No valid input received or operation was canceled.");
                return null;
            }
        }

        public string settings() 
        {
            string weather = GetWeatherFromUser();
            string environment = GetEnvironmentFromUser();
            string time = GetTimeFromUser();
            string text = GetTextFromUser();
            string my_prompt ="I need the weather to be " + weather +
                ", the time to be " + time +
                ", the environment to be " + environment +
                ". Other prompt are: " + text +
                ". Give me a more detailed prompt";
            return my_prompt;
        }
    }
    }
