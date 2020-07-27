using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace RealSurfClub.Controllers
{
    public class ImageFormatHelper
    {
        public static bool IsJpg(HttpPostedFileBase file)
        {
            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Jpeg);
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}