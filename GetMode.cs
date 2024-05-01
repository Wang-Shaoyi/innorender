using Rhino.Input.Custom;
using Rhino.Input;
using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoRender
{
    internal class GetMode
    {
        public bool GetModeFromUser()
        {
            GetOption go = new GetOption();
            go.SetCommandPrompt("Do you want to set a style-reference image (Default: No)");

            // Selections
            go.AddOption("Yes");
            go.AddOption("No");

            // Get input
            if (go.Get() == GetResult.Option)
            {
                var option = go.Option();
                if (option.EnglishName == "Yes")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
