using Rhino.Display;
using Rhino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rhino.Commands;

namespace InnoRender.ImageGet
{
    internal class GetStyleImage
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public GetStyleImage()
        {

        }

        public string SelectImage()
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an Image File";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); 

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    RhinoApp.WriteLine("Selected file path: " + filePath);


                    return filePath;
                }
                return null;
            }
        }
    }
}
