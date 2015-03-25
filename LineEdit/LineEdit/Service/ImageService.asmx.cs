using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using LineEdit.LineEdit.Helper;

namespace LineEdit.LineEdit.Service
{
    /// <summary>
    /// Summary description for ImageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ImageService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string UploadImage(Photo photo)
        {
            //get photofolder path
            string photofolderName = "LineEdit/Images";
            string photopath = "";
            photopath = System.Web.Hosting.HostingEnvironment.MapPath("~/" + photofolderName);
            //convert byte array to image
            Image _photo = ImageHelper.Base64ToImage(photo.photoasBase64);
            var photoname = Guid.NewGuid() + "." + photo.photoType;
            photopath = photopath + "/" + photoname;
            //save photo to folder

            _photo.Save(photopath);
            //chech if photo saved correctlly into folder
            bool result = File.Exists(photopath);

            return "/" + photofolderName + "/" + photoname;
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string RemoveImage(Photo photo)
        {

          var  photopath = System.Web.Hosting.HostingEnvironment.MapPath(photo.url);
          
            //delete photo from folder

            if (System.IO.File.Exists(photopath))
            {
                if (photopath != null) File.Delete(photopath);
            }
            //chech if photo saved correctlly into folder
           

            return "";
        }
        public class Photo
        {
            public string url { get; set; }
            public string photoasBase64 { get; set; }
            public string photoType { get; set; }
        }
    }
}
