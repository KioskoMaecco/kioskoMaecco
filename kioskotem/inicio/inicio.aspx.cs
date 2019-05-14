using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfkiosko;

namespace kioskotem
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objusuario"] == null)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("../default.aspx");
            }
            if (!IsPostBack)
            {
                DataTable usuario = (DataTable)Session["objusuario"];
                lblnombre.Text = usuario.Rows[0]["nombrec"].ToString();
                DateTime thisDay = DateTime.Today;
                // Difference in days, hours, and minutes.
                String tmp = usuario.Rows[0]["fechapass"].ToString();
                if (!tmp.Equals(""))

                {if (Session["inicio"].ToString() == "0")
                {
                    DateTime passDate = Convert.ToDateTime(tmp.Remove(18));
                    TimeSpan ts = thisDay - passDate;

                    // Difference in days.  
                    int differenceInDays = ts.Days;
                    
                    if (differenceInDays >= 90)
                    {
                        Response.Redirect("../Pass.aspx");

                    }
                }
                }
                else
                {
                    if (Session["inicio"].ToString() == "1")
                    {

                    }
                    else
                     {
                        IsvcKioskoClient Manejador = new IsvcKioskoClient();
                        //Guardar Fecha de pass      
                        Tabla MiTabla2 = Manejador.getEjecutaStoredProcedure1("setActualizarFechaPass", usuario.Rows[0]["usuario"].ToString() + "|" + thisDay.ToShortDateString());

                        if (MiTabla2 != null)
                        { 
                            //Response.Redirect("inicio/inicio.aspx");
                        }
                    }

                }
            }
        }
    }
}