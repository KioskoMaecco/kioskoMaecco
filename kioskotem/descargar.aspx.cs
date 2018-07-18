using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kioskotem
{
    public partial class descargar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string tipo = Request.QueryString.Get("tipo");
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Session["archivo"].ToString().Replace(" ", "") + ";");
            Response.ContentType = "application/pdf";
            Response.TransmitFile(Session["ruta"].ToString());
            Response.Flush();
            Response.End();
        }

        private void Download(string patch)
        {
            System.IO.FileInfo toDownload =
                       new System.IO.FileInfo(Server.MapPath(patch));

            Response.Clear();
            Response.AddHeader("Content-Disposition",
                       "attachment; filename=" + toDownload.Name);
            Response.AddHeader("Content-Length",
                        toDownload.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(patch);
            Response.End();
        }
    }
}