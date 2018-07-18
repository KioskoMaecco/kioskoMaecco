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
            if (!IsPostBack)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                
            }
        }

        protected void cmdaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                IsvcKioskoClient Manejador = new IsvcKioskoClient();
                Tabla MiTabla = Manejador.getEjecutaStoredProcedure1("getvalidarusuario",txtcodigo.Text.Replace(" ","X")  + "|" + txtusuario.Text.Replace(" ","X") + "|" + txtcontra.Text.Replace(" ","X") );
                if (MiTabla != null)
                {
                    DataTable dtusuario =  clFunciones.convertToDatatable(MiTabla);
                    if (dtusuario.Rows[0]["fkIdPerfil"].ToString() == "1")
                    {

                        Response.Redirect("Buscar.aspx");

                    }
                    else
                    {
                        if (dtusuario.Rows[0]["privacidad"].ToString() == "0")
                        {
                            Session["objusuario"] = dtusuario;
                            Session["idusuario"] = dtusuario.Rows[0]["IdUsuario"].ToString();
                            Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                            Response.Redirect("privacidad.aspx");
                        }
                        //ValidateMail
                        else
                        {
                            if (dtusuario.Rows[0]["verificaremail"].ToString() == "0")
                            {
                                Session["objusuario"] = dtusuario;
                                Session["idusuario"] = dtusuario.Rows[0]["IdUsuario"].ToString();
                                Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                                Response.Redirect("ValidarEmail.aspx");
                            }
                            else
                            {

                                Session["objusuario"] = dtusuario;
                                Session["idusuario"] = dtusuario.Rows[0]["IdUsuario"].ToString();
                                Session["idcodigo"] = dtusuario.Rows[0]["codigo"].ToString();
                                Response.Redirect("inicio/inicio.aspx", false);



                            }
                        }

                    }
                    
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


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recuperar.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Soporte.aspx");
        }
    }
}