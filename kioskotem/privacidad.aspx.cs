﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfkiosko;

namespace kioskotem
{
    public partial class privacidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["objusuario"] == null)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("default.aspx");
            }
        }

        protected void cmdaceptar_Click(object sender, EventArgs e)
        {
            if (chkacepto.Checked == true)
            {
                //insertamos la modificacion en la base de datos
                IsvcKioskoClient Manejador = new IsvcKioskoClient();
                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("setActualizarPrivacidad", Session["idusuario"].ToString() + "|" + Session["idcodigo"].ToString());
                if (MiTabla != null)
                {
                    //DataTable dtusuario = clFunciones.convertToDatatable(MiTabla);
                    Response.Redirect("inicio/inicio.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Datos no guardados, intente de nuevo');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, typeof(string), "alerta", "alert('Favor de aceptar los terminos y condiciones para continuar');", true);
            }

        }

        protected void cmdcancelar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("default.aspx");
        }

        
    }
}