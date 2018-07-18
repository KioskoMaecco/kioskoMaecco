using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kioskotem
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objusuario"] == null)
            {
                Response.Redirect("default.aspx");
            }
            if (!IsPostBack)
            {
                DataTable usuario = (DataTable)Session["objusuario"];
                lblnombre.Text = usuario.Rows[0]["nombrec"].ToString();
                
            }
        }
    }
}