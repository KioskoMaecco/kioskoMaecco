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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                IsvcKioskoClient Manejador = new IsvcKioskoClient();
                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("getvalidarusuario",txtcodigo.Text + "|" + txtusuario.Text + "|" + txtcontra.Text);
                if (MiTabla != null)
                {
                    DataTable dtusuario =  clFunciones.convertToDatatable(MiTabla);

                    Session["objusuario"] = dtusuario;
                    Response.Redirect("inicio.aspx");

                    //if (dtusuario.Rows[0]["fkIdPerfil"].ToString() == "2")
                    //{
                    //    Response.Redirect("facturas.aspx");
                    //}
                    //else if (dtusuario.Rows[0]["tipo"].ToString() == "2")
                    //{
                    //    Response.Redirect("verfacturas.aspx");
                    //}
                    //else if (dtusuario.Rows[0]["tipo"].ToString() == "3")
                    //{
                    //    Response.Redirect("verfacturas.aspx");
                    //}

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Usuario o contraseña incorrecta');", true);
                }


            }
            catch (Exception EX)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('" + EX.Message + "');", true);
            }

        }
    }
}