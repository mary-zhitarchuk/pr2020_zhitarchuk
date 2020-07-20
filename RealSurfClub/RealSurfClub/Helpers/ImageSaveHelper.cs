using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.IO;
using System.Runtime.Versioning;

namespace RealSurfClub.Helpers
{
    public class ImageSaveHelper
    {
        public static Guid SaveImage(HttpPostedFileBase image)
        {
            Guid fname = Guid.NewGuid();
            var filename = fname + ".jpg";
            var path = HostingEnvironment.MapPath("/Content/Images/Uploads");
            var savedFilename = Path.Combine(path, filename);

            image.SaveAs(savedFilename);

            return fname;
        }
    }
}