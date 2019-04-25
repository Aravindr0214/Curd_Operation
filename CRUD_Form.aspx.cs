using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_Operation
{
    public partial class CRUD_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridview();
            }
        }
        protected void BindGridview()
        {
            string[] filesPath = Directory.GetFiles(Server.MapPath("~/Image/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string path in filesPath)
            {
                files.Add(new ListItem(Path.GetFileName(path)));
            }
            View_files.DataSource = files;
            View_files.DataBind();
        }

        string filePath = ConfigurationManager.AppSettings["Uploaded_file_path"].ToString();
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (UploadFile_Server.HasFile)
            {
                try
                {
                    //UploadFile_Server.SaveAs(filePath + "" + UploadFile_Server.FileName);
                    foreach (HttpPostedFile uploadedFile in UploadFile_Server.PostedFiles)
                    {
                        uploadedFile.SaveAs(filePath+""+ uploadedFile.FileName);
                      //listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        protected void Download_Click(object sender, EventArgs e)
        {
            using (ZipFile zip = new ZipFile())
            {
                string fileName = "";
                string filePath = "";
                foreach (GridViewRow row in View_files.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk.Checked)
                    {
                        fileName = row.Cells[1].Text;
                        filePath = Server.MapPath("~/Image/" + fileName);
                        zip.AddFile(filePath, "files");

                    }
                }
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=ZipFile.zip");
                Response.ContentType = "application/zip";
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }
    }
}


