using Rhino.Display;
using Rhino;
using System;

using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace InnoRender.Capture
{
    internal class ViewCaptureInno
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }

        public ViewCaptureInno()
        {
            
        }

        public string CaptureAndView()
        {
            RhinoDoc doc = RhinoDoc.ActiveDoc;
            RhinoView view = doc.Views.ActiveView;
            if (view == null)
                return null;

            using (var folderDialog = new FolderBrowserDialog())
            {

                string tempFileName = System.IO.Path.GetTempFileName();
                string fileName = System.IO.Path.ChangeExtension(tempFileName, ".png");

 
                Bitmap bitmap = view.CaptureToBitmap();
                if (bitmap != null)
                {
                    bitmap.Save(fileName, ImageFormat.Png);
                    bitmap.Dispose();
                    
                    return fileName;
                }
                return null;
            }

            
        }
    }
}
