﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using kioskotem.wcfkiosko;

namespace kioskotem.nomina
{
    public partial class comprobante : System.Web.UI.Page
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

                dtpinicio.SelectedDate = DateTime.Parse("01/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                dtpfinal.SelectedDate = DateTime.Parse(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);


            }

        }

        protected void dtgnominas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dtgnominas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    int id = Convert.ToInt32(e.CommandArgument);


                    //DateTime fecha = DateTime.Parse(((Label)dtgnominas.Rows[id].FindControl("lblfecha")).Text);
                    string sa = ((Label)dtgnominas.Rows[id].FindControl("lbldpagosa")).Text;

                    Session["ruta"] = "pagosn/" + sa + ".pdf";
                    String path = Server.MapPath("../pagosn") + "\\" + sa + ".pdf";

                    String path2 = "../pagosn/" + sa + ".pdf";

                    Session["archivo"] = sa + ".pdf";
                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    if (toDownload.Exists)
                    {
                        Response.Redirect("../descargar.aspx", false);
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + path2 + "','_blank')", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('No se encuentra el archivo ');", true);

                    }

                }
                if (e.CommandName == "Delete")
                {
                    int id = Convert.ToInt32(e.CommandArgument);


                    //DateTime fecha = DateTime.Parse(((Label)dtgnominas.Rows[id].FindControl("lblfecha")).Text);
                    string sindicato = ((Label)dtgnominas.Rows[id].FindControl("lbldpagosin")).Text;

                    Session["ruta"] = "pagosn/" + sindicato + ".pdf";
                    String path = Server.MapPath("../pagosn") + "\\" + sindicato + ".pdf";
                    String path2 = "../pagosn/" + sindicato + ".pdf";

                    Session["archivo"] = sindicato + ".pdf";

                    System.IO.FileInfo toDownload = new System.IO.FileInfo(path);
                    if (toDownload.Exists)
                    {
                        Response.Redirect("../descargar.aspx");
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open('" + path2 + "','_blank')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "alert", "alert('No se encuentra el archivo ');", true);

                    }

                }
            }
            catch (Exception EX)
            {
                //clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
            }
        }



        protected void dtgnominas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dtgnominas.DataSource = (DataSet)Session["dsPagos"];
            dtgnominas.PageIndex = e.NewPageIndex;
            dtgnominas.DataBind();
        }

        protected void cmdbuscar_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = "";

            cargar_grid();
        }


        private void cargar_grid()
        {
            wcfkiosko.IsvcKioskoClient Manejador = new IsvcKioskoClient();


            DataSet dsEmpresas = new DataSet();
            dsEmpresas.Tables.Add("Tabla");
            dsEmpresas.Tables[0].Columns.Add("iIdPago");
            dsEmpresas.Tables[0].Columns.Add("dpagosa");
            dsEmpresas.Tables[0].Columns.Add("dpagosin");
            dsEmpresas.Tables[0].Columns.Add("Fecha");
            dsEmpresas.Tables[0].Columns.Add("importe");
            dsEmpresas.Tables[0].Columns.Add("importesin");

            DateTime inicio = DateTime.Parse(dtpinicio.SelectedDate.ToString());
            DateTime final = DateTime.Parse(dtpfinal.SelectedDate.ToString());
            string inicial = inicio.Year.ToString() + inicio.Month.ToString("00") + inicio.Day.ToString("00");
            string fin = final.Year.ToString() + final.Month.ToString("00") + final.Day.ToString("00");



            try
            {
                Tabla tbEmpresas = Manejador.getEjecutaStoredProcedure1("getpagosnomina", "1|" + Session["idusuario"].ToString() + "|" + inicial + "|" + fin);
                if (tbEmpresas != null)
                {
                    DataTable dtEmpresas = clFunciones.convertToDatatable(tbEmpresas);
                    for (int x = 0; x < dtEmpresas.Rows.Count; x++)
                    {
                        dsEmpresas.Tables[0].Rows.Add(dtEmpresas.Rows[x]["iIdPago"],
                                                        dtEmpresas.Rows[x]["dpago"],
                                                        dtEmpresas.Rows[x]["dsindicato"],
                                                        DateTime.Parse(dtEmpresas.Rows[x]["Fecha"].ToString()).ToShortDateString(),
                                                        dtEmpresas.Rows[x]["importe"],
                                                        dtEmpresas.Rows[x]["importesin"]);



                    }

                    Session["dsPagos"] = dsEmpresas;
                    dtgnominas.DataSource = dsEmpresas;

                }
                else
                {
                    Session["dsPagos"] = null;
                    dtgnominas.DataSource = null;
                    lblmensaje.Text = "Sin Pagos Recientes";

                }
                dtgnominas.DataBind();

            }
            catch (Exception EX)
            {
                clFunciones.JQMensaje(this, EX.Message.Replace("'", ""), TipoMensaje.Error);
            }

        }
    }
}