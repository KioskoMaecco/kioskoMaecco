using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Text;

using System.Web.UI.WebControls;
using System.Data;
using kioskotem.wcfkiosko;


/// <summary>
/// Descripci&oacute;n breve de EnviarCorreos
/// </summary>
public class EnviarCorreos
{
	public EnviarCorreos()
	{
   
        //
		// TODO: Agregar aqu&iacute; la l&oacute;gica del constructor
		//
	}

    static string mensajeError = "";
    public static Boolean enviarCorreo(string email, string pagina, string asunto)
    {
        //MailMessage correo = new MailMessage();
        //correo.From = new MailAddress("raymundo.schulz@contanetica.com");
        //correo.To.Add(email);
        //correo.Subject = asunto;
        ////correo.Body = leerPaginaWeb(pagina);
        //correo.Body = pagina;
        //correo.IsBodyHtml = true;
        ////correo.Priority = MailPriority.Normal();
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "contanetica.com";
        try
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(email);
            msg.From = new MailAddress("soporte@mbcgroup.mx", "Maecco SA", Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = pagina;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("omar.perez@contanetica.com", "omarp");
            client.Credentials = new System.Net.NetworkCredential("soporte@mbcgroup.mx", "@tortadejamon");
            client.Port = 26;
            //client.Host = "contanetica.com";
            client.Host = "mbcgroup.mx";
            //client.EnableSsl = true; //Esto es para que vaya a través de SSL

            client.Send(msg);

            //smtp.Send(correo);
            return true;
            //Response.Write("Correo Enviado");
        }
        catch (Exception ex)
        {
            mensajeError = "No se pudo enviar el correo " + ex.Message;
            return false;
        }
    }

    //public static string paginaCliente(string nombres, string apellidos, string correo, string passwd, string producto, string imgproducto)
    public static string paginaConfirmar(string NombresContacto,  string NombreProducto,  string ClaveAcceso)
    {
        string confirmacionCliente=
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +

            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
            "<head>" +
                "<title></title>" +
                "<link href='http://avizorregistro.contanetica-saas.com/Styles/Style.css' rel='stylesheet' type='text/css' />" +
            "</head>" +
            "<body style='background-color:#FFFFFF;'>" +

            "<div class='plantilla'>" +
                "<div class='banner'>"+"<div class='login-logo'>"+
                "<a href='#'><b>Maecco</b>SA</a>"+
             " </div></div>" +
                "<div class='titulo'>Gracias por registrarse.</div>" +
                "<div class='contenido'>" +
                    "<p>" +
                        "Estimado: <strong>" + NombresContacto + " " + "</strong>" +
                        "<br />" +
                        "Para continuar con el proceso de registro en <strong>" + NombreProducto + "</strong>, es necesario nos confirme haciendo click en el siguiente link " +
                        "<br />" +
                        "<span style='text-align:center;'><a href='http://www.maecco.net/recibos/Verificar.aspx?ca=" + ClaveAcceso + "' target='_new'>http://www.maecco.net/recibos/Verificar.aspx</a></span>" +
                        "<br />" +
                        "o copie y pegue el contenido en la barra de navegaci&oacute;n de su explorador." +
                    "</p>" +
                "</div>" +
                "<div align='center'>" +
                    "<p>" + 
                    "Este correo se genera de manera automatica. Porfavor, no responda." +
                    "</p>" +
                    "</div>" +
            "</div>" +

            "</body>" +
            "</html>";
        return confirmacionCliente;
    }


    public static string paginaRecuperar(string NombresContacto,  string ClaveAcceso)
    {
        string confirmacionCliente =
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +

           "<html xmlns='http://www.w3.org/1999/xhtml'>" +
           "<head>" +
               "<title></title>" +
               
           "</head>" +
           "<body style='background-color:#FFFFFF;'>" +

           "<div class='plantilla'>" +
               "<div class='banner'>"+"<div class='login-logo'>"+
                "<a href='#'><b>Maecco</b>SA</a>"+
             " </div></div>" +"</div>" +
               "<div class='titulo'>Gracias por registrarse.</div>" +
               "<div class='contenido'>" +
                   "<p>" +
                       "Estimado: <strong>" + NombresContacto + " " + "</strong>" +
                       "<br />" +
                       "Para continuar con el proceso de registro en <strong>Maecco SA</strong>, es necesario nos confirme haciendo click en el siguiente link " +
                       "<br />" +
                       "<span style='text-align:center;'><a href='http://www.maecco.net/recibos/CambiarPassword.aspx?ca=" + ClaveAcceso + "' target='_new'>http://www.maecco.net/recibos/CambiarPassword.aspx</a></span>" +
                       "<br />" +
                       "o copie y pegue el contenido en la barra de navegaci&oacute;n de su explorador." +
                   "</p>" +
               "</div>" +
               "<div align='center'>" +
                 "<p>" +
                    "Este correo se genera de manera automatica. Porfavor, no responda." +
                    "</p>" + 
                    "</div>" +
           "</div>" +

           "</body>" +
           "</html>";
        return confirmacionCliente;
    }


    public static string paginaCambio(string NombresContacto)
    {
        string confirmacionCliente =
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +

            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
            "<head>" +
                "<title></title>" +
                "<link href='http://avizorregistro.contanetica-saas.com/Styles/Style.css' rel='stylesheet' type='text/css' />" +
            "</head>" +
            "<body style='background-color:#FFFFFF;'>" +

            "<div class='plantilla'>" +
                "<a href='#'><b>Maecco</b>SA</a>" + 
                "<div class='titulo'></div>" +
                "<div class='contenido'>" +
                    "<p>" +
                        "Estimado: <strong>" + NombresContacto + " " + "</strong>" +
                        "<br />" +
                        "<br />" +
                        "Se ha vinculado este correo a su cuenta en <strong>www.maecco.net</strong>  correctamente" +
                    "</p>" +
                "</div>" +
                "<div align='center'>" +
                    "<p>" +
                    "Este correo se genera de manera automatica. Porfavor, no responda." +
                    "</p>" +
                    "</div>" +
            "</div>" +

            "</body>" +
            "</html>";
        return confirmacionCliente;
    }


}