using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CRUD_Operation
{
    /// <summary>
    /// Summary description for Upload_File
    /// </summary>
    public class Upload_File : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("");
            try
        {
            string dirFullPath = HttpContext.Current.Server.MapPath("~/Image/");
            string[] files;
            int numFiles;
            files = System.IO.Directory.GetFiles(dirFullPath);
            numFiles = files.Length+1;
           // numFiles = numFiles + 1;
            string str_image = "";

            foreach (string s in context.Request.Files)
            {
                HttpPostedFile file = context.Request.Files[s];
        string fileName = file.FileName;
        string fileExtension = file.ContentType;

                if (!string.IsNullOrEmpty(fileName))
                {
                    fileExtension = Path.GetExtension(fileName);
                    str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
        file.SaveAs(dirFullPath + str_image);
                                 }
}
//  database record update logic here  ()

context.Response.Write(str_image);
        }
        catch (Exception ac) 
        { 

        }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}