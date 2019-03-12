using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModelos;
using System.Net.Mail;

namespace Comunes
{
    public class SCOrdenCompraComunes
    {
        public static string url = "http://192.168.2.58/lafarnet/#/sc/";
        public void enviarEmail(Email email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpserver = new SmtpClient("lafar.net");
            mail.From = new MailAddress(email.From);
            mail.To.Add(email.To);
            mail.Subject = email.Subject;
            mail.Body = email.Body;
            mail.IsBodyHtml = true;

            smtpserver.Port = 587;
            smtpserver.Credentials = new System.Net.NetworkCredential("solicitudcompras@lafar.net", "80BiO1hU8wzq");
            smtpserver.EnableSsl = false;
            smtpserver.Send(mail);
        }

        public string bodyEmailNuevaOrden(SCUsuarios solicitante, NotificacionOrden orden)
        {
            string body = "<!doctype html>" +
                "<html>" +
                "<head>" +
                "<meta name='viewport' content='width=device-width' />" +
                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                "<title>Orden de Compra</title>" +
                "<style>" +
                "/* -------------------------------------" +
                "GLOBAL RESETS" +
                "------------------------------------- */" +
                "" +
                "/*All the styling goes here*/" +
                "" +
                "img {" +
                "border: none;" +
                "-ms-interpolation-mode: bicubic;" +
                "max-width: 100%;" +
                "}" +
                "" +
                "body {" +
                "background-color: #f6f6f6;" +
                "font-family: sans-serif;" +
                "-webkit-font-smoothing: antialiased;" +
                "font-size: 14px;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "padding: 0;" +
                "-ms-text-size-adjust: 100%;" +
                "-webkit-text-size-adjust: 100%;" +
                "}" +
                "" +
                "table {" +
                "border-collapse: separate;" +
                "mso-table-lspace: 0pt;" +
                "mso-table-rspace: 0pt;" +
                "width: 100%; }" +
                "table td {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "vertical-align: top;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BODY & CONTAINER" +
                "------------------------------------- */" +
                "" +
                ".body {" +
                "background-color: #f6f6f6;" +
                "width: 100%;" +
                "}" +
                "" +
                "/* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */" +
                ".container {" +
                "display: block;" +
                "Margin: 0 auto !important;" +
                "/* makes it centered */" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "width: 580px;" +
                "}" +
                "" +
                "/* This should also be a block element, so that it will fill 100% of the .container */" +
                ".content {" +
                "box-sizing: border-box;" +
                "display: block;" +
                "Margin: 0 auto;" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "HEADER, FOOTER, MAIN" +
                "------------------------------------- */" +
                ".main {" +
                "background: #ffffff;" +
                "border-radius: 3px;" +
                "width: 100%;" +
                "}" +
                "" +
                ".wrapper {" +
                "box-sizing: border-box;" +
                "padding: 20px;" +
                "}" +
                "" +
                ".content-block {" +
                "padding-bottom: 10px;" +
                "padding-top: 10px;" +
                "}" +
                "" +
                ".footer {" +
                "clear: both;" +
                "Margin-top: 10px;" +
                "text-align: center;" +
                "width: 100%;" +
                "}" +
                ".footer td," +
                ".footer p," +
                ".footer span," +
                ".footer a {" +
                "color: #999999;" +
                "font-size: 12px;" +
                "text-align: center;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "TYPOGRAPHY" +
                "------------------------------------- */" +
                "h1," +
                "h2," +
                "h3," +
                "h4 {" +
                "color: #000000;" +
                "font-family: sans-serif;" +
                "font-weight: 400;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "margin-bottom: 30px;" +
                "}" +
                "" +
                "h1 {" +
                "font-size: 35px;" +
                "font-weight: 300;" +
                "text-align: center;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                "p," +
                "ul," +
                "ol {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "font-weight: normal;" +
                "margin: 0;" +
                "margin-bottom: 15px;" +
                "}" +
                "p li," +
                "ul li," +
                "ol li {" +
                "list-style-position: inside;" +
                "margin-left: 5px;" +
                "}" +
                "" +
                "a {" +
                "color: #3498db;" +
                "text-decoration: underline;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BUTTONS" +
                "------------------------------------- */" +
                ".btn {" +
                "box-sizing: border-box;" +
                "width: 100%; }" +
                ".btn > tbody > tr > td {" +
                "padding-bottom: 15px; }" +
                ".btn table {" +
                "width: auto;" +
                "}" +
                ".btn table td {" +
                "background-color: #ffffff;" +
                "border-radius: 5px;" +
                "text-align: center;" +
                "}" +
                ".btn a {" +
                "background-color: #ffffff;" +
                "border: solid 1px #3498db;" +
                "border-radius: 5px;" +
                "box-sizing: border-box;" +
                "color: #3498db;" +
                "cursor: pointer;" +
                "display: inline-block;" +
                "font-size: 14px;" +
                "font-weight: bold;" +
                "margin: 0;" +
                "padding: 12px 25px;" +
                "text-decoration: none;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                ".btn-primary table td {" +
                "background-color: #3498db;" +
                "}" +
                "" +
                ".btn-primary a {" +
                "background-color: #3498db;" +
                "border-color: #3498db;" +
                "color: #ffffff;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "OTHER STYLES THAT MIGHT BE USEFUL" +
                "------------------------------------- */" +
                ".last {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".first {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".align-center {" +
                "text-align: center;" +
                "}" +
                "" +
                ".align-right {" +
                "text-align: right;" +
                "}" +
                "" +
                ".align-left {" +
                "text-align: left;" +
                "}" +
                "" +
                ".clear {" +
                "clear: both;" +
                "}" +
                "" +
                ".mt0 {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".mb0 {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".preheader {" +
                "color: transparent;" +
                "display: none;" +
                "height: 0;" +
                "max-height: 0;" +
                "max-width: 0;" +
                "opacity: 0;" +
                "overflow: hidden;" +
                "mso-hide: all;" +
                "visibility: hidden;" +
                "width: 0;" +
                "}" +
                "" +
                ".powered-by a {" +
                "text-decoration: none;" +
                "}" +
                "" +
                "hr {" +
                "border: 0;" +
                "border-bottom: 1px solid #f6f6f6;" +
                "Margin: 20px 0;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "RESPONSIVE AND MOBILE FRIENDLY STYLES" +
                "------------------------------------- */" +
                "@media only screen and (max-width: 620px) {" +
                "table[class=body] h1 {" +
                "font-size: 28px !important;" +
                "margin-bottom: 10px !important;" +
                "}" +
                "table[class=body] p," +
                "table[class=body] ul," +
                "table[class=body] ol," +
                "table[class=body] td," +
                "table[class=body] span," +
                "table[class=body] a {" +
                "font-size: 16px !important;" +
                "}" +
                "table[class=body] .wrapper," +
                "table[class=body] .article {" +
                "padding: 10px !important;" +
                "}" +
                "table[class=body] .content {" +
                "padding: 0 !important;" +
                "}" +
                "table[class=body] .container {" +
                "padding: 0 !important;" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .main {" +
                "border-left-width: 0 !important;" +
                "border-radius: 0 !important;" +
                "border-right-width: 0 !important;" +
                "}" +
                "table[class=body] .btn table {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .btn a {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .img-responsive {" +
                "height: auto !important;" +
                "max-width: 100% !important;" +
                "width: auto !important;" +
                "}" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "PRESERVE THESE STYLES IN THE HEAD" +
                "------------------------------------- */" +
                "@media all {" +
                ".ExternalClass {" +
                "width: 100%;" +
                "}" +
                ".ExternalClass," +
                ".ExternalClass p," +
                ".ExternalClass span," +
                ".ExternalClass font," +
                ".ExternalClass td," +
                ".ExternalClass div {" +
                "line-height: 100%;" +
                "}" +
                ".apple-link a {" +
                "color: inherit !important;" +
                "font-family: inherit !important;" +
                "font-size: inherit !important;" +
                "font-weight: inherit !important;" +
                "line-height: inherit !important;" +
                "text-decoration: none !important;" +
                "}" +
                ".btn-primary table td:hover {" +
                "background-color: #34495e !important;" +
                "}" +
                ".btn-primary a:hover {" +
                "background-color: #34495e !important;" +
                "border-color: #34495e !important;" +
                "}" +
                "}" +
                "" +
                "</style>" +
                "</head>" +
                "<body class=''>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body'>" +
                "<tr>" +
                "<td>&nbsp;</td>" +
                "<td class='container'>" +
                "<div class='content'>" +
                "" +
                "<!-- START CENTERED WHITE CONTAINER -->" +
                "<span class='preheader'>Estimad@, '" + solicitante.nombre_completo + @"'. Se ha creado una nueva orden de compra .</span>" +
                "<table role='presentation' class='main'>" +
                "" +
                "<!-- START MAIN CONTENT AREA -->" +
                "<tr>" +
                "<td class='wrapper'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td>" +
                "<p>Estimad@ " + solicitante.nombre_completo + ",</p>" +
                "<p>Se ha creado una Orden de Compra Nro: "+orden.codigo_orden+" donde se incluyo articulos de la solicitud de compra Nro:" + orden.codigo_solicitud + " que fue creada por usted. Para ver mas detalles de la solicitud presione el boton y sera redireccionado.</p>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='btn btn-primary'>" +
                "<tbody>" +
                "<tr>" +
                "<td align='left'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tbody>" +
                "<tr>" +
                "<td> <a class='btn-primary' href='" + url + "solicitud/detail/" + orden.codigo_solicitud + @"' target='_blank'>Abrir Solicitud</a> </td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<p>Si tiene problemas al abrir esta solicitud directamente. Puede ingresar a <a href='http://intranet.lafar.net' target='_blank'>http://intranet.lafar.net</a>. Ingrese a la Aplicación Sistema de Compras y verifique su listado de solicitudes " +
                "<p>En otro caso comuniquese con el área de Sistemas LAFAR.</p>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "" +
                "<!-- END MAIN CONTENT AREA -->" +
                "</table>" +
                "" +
                "<!-- START FOOTER -->" +
                "<div class='footer'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td class='content-block'>" +
                "<span class='apple-link'>LABORATORIOS FARMACEUTICOS LAFAR S.A., Calle Luis Crespo # 2213 Zona de Sopocachi</span>" +
                "<br> Puede visitarnos a la pagina web <a href='http://www.lafar.net'>http://www.lafar.net</a>." +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td class='content-block powered-by'>" +
                "" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</div>" +
                "<!-- END FOOTER -->" +
                "" +
                "<!-- END CENTERED WHITE CONTAINER -->" +
                "</div>" +
                "</td>" +
                "<td>&nbsp;</td>" +
                "</tr>" +
                "</table>" +
                "</body>" +
                "</html>" +
                "";
            return body;
        }

        public string bodyEmailAnularOrden(SCUsuarios solicitante, NotificacionOrden n, OCOrdenCompra orden)
        {
            string body = "<!doctype html>" +
                "<html>" +
                "<head>" +
                "<meta name='viewport' content='width=device-width' />" +
                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                "<title>Orden de Compra</title>" +
                "<style>" +
                "/* -------------------------------------" +
                "GLOBAL RESETS" +
                "------------------------------------- */" +
                "" +
                "/*All the styling goes here*/" +
                "" +
                "img {" +
                "border: none;" +
                "-ms-interpolation-mode: bicubic;" +
                "max-width: 100%;" +
                "}" +
                "" +
                "body {" +
                "background-color: #f6f6f6;" +
                "font-family: sans-serif;" +
                "-webkit-font-smoothing: antialiased;" +
                "font-size: 14px;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "padding: 0;" +
                "-ms-text-size-adjust: 100%;" +
                "-webkit-text-size-adjust: 100%;" +
                "}" +
                "" +
                "table {" +
                "border-collapse: separate;" +
                "mso-table-lspace: 0pt;" +
                "mso-table-rspace: 0pt;" +
                "width: 100%; }" +
                "table td {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "vertical-align: top;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BODY & CONTAINER" +
                "------------------------------------- */" +
                "" +
                ".body {" +
                "background-color: #f6f6f6;" +
                "width: 100%;" +
                "}" +
                "" +
                "/* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */" +
                ".container {" +
                "display: block;" +
                "Margin: 0 auto !important;" +
                "/* makes it centered */" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "width: 580px;" +
                "}" +
                "" +
                "/* This should also be a block element, so that it will fill 100% of the .container */" +
                ".content {" +
                "box-sizing: border-box;" +
                "display: block;" +
                "Margin: 0 auto;" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "HEADER, FOOTER, MAIN" +
                "------------------------------------- */" +
                ".main {" +
                "background: #ffffff;" +
                "border-radius: 3px;" +
                "width: 100%;" +
                "}" +
                "" +
                ".wrapper {" +
                "box-sizing: border-box;" +
                "padding: 20px;" +
                "}" +
                "" +
                ".content-block {" +
                "padding-bottom: 10px;" +
                "padding-top: 10px;" +
                "}" +
                "" +
                ".footer {" +
                "clear: both;" +
                "Margin-top: 10px;" +
                "text-align: center;" +
                "width: 100%;" +
                "}" +
                ".footer td," +
                ".footer p," +
                ".footer span," +
                ".footer a {" +
                "color: #999999;" +
                "font-size: 12px;" +
                "text-align: center;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "TYPOGRAPHY" +
                "------------------------------------- */" +
                "h1," +
                "h2," +
                "h3," +
                "h4 {" +
                "color: #000000;" +
                "font-family: sans-serif;" +
                "font-weight: 400;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "margin-bottom: 30px;" +
                "}" +
                "" +
                "h1 {" +
                "font-size: 35px;" +
                "font-weight: 300;" +
                "text-align: center;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                "p," +
                "ul," +
                "ol {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "font-weight: normal;" +
                "margin: 0;" +
                "margin-bottom: 15px;" +
                "}" +
                "p li," +
                "ul li," +
                "ol li {" +
                "list-style-position: inside;" +
                "margin-left: 5px;" +
                "}" +
                "" +
                "a {" +
                "color: #3498db;" +
                "text-decoration: underline;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BUTTONS" +
                "------------------------------------- */" +
                ".btn {" +
                "box-sizing: border-box;" +
                "width: 100%; }" +
                ".btn > tbody > tr > td {" +
                "padding-bottom: 15px; }" +
                ".btn table {" +
                "width: auto;" +
                "}" +
                ".btn table td {" +
                "background-color: #ffffff;" +
                "border-radius: 5px;" +
                "text-align: center;" +
                "}" +
                ".btn a {" +
                "background-color: #ffffff;" +
                "border: solid 1px #3498db;" +
                "border-radius: 5px;" +
                "box-sizing: border-box;" +
                "color: #3498db;" +
                "cursor: pointer;" +
                "display: inline-block;" +
                "font-size: 14px;" +
                "font-weight: bold;" +
                "margin: 0;" +
                "padding: 12px 25px;" +
                "text-decoration: none;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                ".btn-primary table td {" +
                "background-color: #3498db;" +
                "}" +
                "" +
                ".btn-primary a {" +
                "background-color: #3498db;" +
                "border-color: #3498db;" +
                "color: #ffffff;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "OTHER STYLES THAT MIGHT BE USEFUL" +
                "------------------------------------- */" +
                ".last {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".first {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".align-center {" +
                "text-align: center;" +
                "}" +
                "" +
                ".align-right {" +
                "text-align: right;" +
                "}" +
                "" +
                ".align-left {" +
                "text-align: left;" +
                "}" +
                "" +
                ".clear {" +
                "clear: both;" +
                "}" +
                "" +
                ".mt0 {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".mb0 {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".preheader {" +
                "color: transparent;" +
                "display: none;" +
                "height: 0;" +
                "max-height: 0;" +
                "max-width: 0;" +
                "opacity: 0;" +
                "overflow: hidden;" +
                "mso-hide: all;" +
                "visibility: hidden;" +
                "width: 0;" +
                "}" +
                "" +
                ".powered-by a {" +
                "text-decoration: none;" +
                "}" +
                "" +
                "hr {" +
                "border: 0;" +
                "border-bottom: 1px solid #f6f6f6;" +
                "Margin: 20px 0;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "RESPONSIVE AND MOBILE FRIENDLY STYLES" +
                "------------------------------------- */" +
                "@media only screen and (max-width: 620px) {" +
                "table[class=body] h1 {" +
                "font-size: 28px !important;" +
                "margin-bottom: 10px !important;" +
                "}" +
                "table[class=body] p," +
                "table[class=body] ul," +
                "table[class=body] ol," +
                "table[class=body] td," +
                "table[class=body] span," +
                "table[class=body] a {" +
                "font-size: 16px !important;" +
                "}" +
                "table[class=body] .wrapper," +
                "table[class=body] .article {" +
                "padding: 10px !important;" +
                "}" +
                "table[class=body] .content {" +
                "padding: 0 !important;" +
                "}" +
                "table[class=body] .container {" +
                "padding: 0 !important;" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .main {" +
                "border-left-width: 0 !important;" +
                "border-radius: 0 !important;" +
                "border-right-width: 0 !important;" +
                "}" +
                "table[class=body] .btn table {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .btn a {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .img-responsive {" +
                "height: auto !important;" +
                "max-width: 100% !important;" +
                "width: auto !important;" +
                "}" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "PRESERVE THESE STYLES IN THE HEAD" +
                "------------------------------------- */" +
                "@media all {" +
                ".ExternalClass {" +
                "width: 100%;" +
                "}" +
                ".ExternalClass," +
                ".ExternalClass p," +
                ".ExternalClass span," +
                ".ExternalClass font," +
                ".ExternalClass td," +
                ".ExternalClass div {" +
                "line-height: 100%;" +
                "}" +
                ".apple-link a {" +
                "color: inherit !important;" +
                "font-family: inherit !important;" +
                "font-size: inherit !important;" +
                "font-weight: inherit !important;" +
                "line-height: inherit !important;" +
                "text-decoration: none !important;" +
                "}" +
                ".btn-primary table td:hover {" +
                "background-color: #34495e !important;" +
                "}" +
                ".btn-primary a:hover {" +
                "background-color: #34495e !important;" +
                "border-color: #34495e !important;" +
                "}" +
                "}" +
                "" +
                "</style>" +
                "</head>" +
                "<body class=''>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body'>" +
                "<tr>" +
                "<td>&nbsp;</td>" +
                "<td class='container'>" +
                "<div class='content'>" +
                "" +
                "<!-- START CENTERED WHITE CONTAINER -->" +
                "<span class='preheader'>Estimad@, '" + solicitante.nombre_completo + @"'. Se anulo la orden de compra por SubGerencia.</span>" +
                "<table role='presentation' class='main'>" +
                "" +
                "<!-- START MAIN CONTENT AREA -->" +
                "<tr>" +
                "<td class='wrapper'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td>" +
                "<p>Estimad@ " + solicitante.nombre_completo + ",</p>" +
                "<p>La Orden de Compra Nro: " + orden.codigo_orden + " donde se incluyo articulos de la solicitud de compra Nro:" + n.codigo_solicitud + " que fue creada por usted. Ha sido anulada, por el siguiente motivo: "+ orden.motivo_anulacion +".</p>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='btn btn-primary'>" +
                "<tbody>" +
                "<tr>" +
                "<td align='left'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tbody>" +
                "<tr>" +
                "<td> <a class='btn-primary' href='" + url + "solicitud/detail/" + n.codigo_solicitud + @"' target='_blank'>Abrir Solicitud</a> </td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<p>Si tiene problemas al abrir esta solicitud directamente. Puede ingresar a <a href='http://intranet.lafar.net' target='_blank'>http://intranet.lafar.net</a>. Ingrese a la Aplicación Sistema de Compras y verifique su listado de solicitudes " +
                "<p>En otro caso comuniquese con el área de Sistemas LAFAR.</p>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "" +
                "<!-- END MAIN CONTENT AREA -->" +
                "</table>" +
                "" +
                "<!-- START FOOTER -->" +
                "<div class='footer'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td class='content-block'>" +
                "<span class='apple-link'>LABORATORIOS FARMACEUTICOS LAFAR S.A., Calle Luis Crespo # 2213 Zona de Sopocachi</span>" +
                "<br> Puede visitarnos a la pagina web <a href='http://www.lafar.net'>http://www.lafar.net</a>." +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td class='content-block powered-by'>" +
                "" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</div>" +
                "<!-- END FOOTER -->" +
                "" +
                "<!-- END CENTERED WHITE CONTAINER -->" +
                "</div>" +
                "</td>" +
                "<td>&nbsp;</td>" +
                "</tr>" +
                "</table>" +
                "</body>" +
                "</html>" +
                "";
            return body;
        }

        public string bodyEmailRechazarOrden(SCUsuarios solicitante, NotificacionOrden n, OCOrdenCompra orden)
        {
            string body = "<!doctype html>" +
                "<html>" +
                "<head>" +
                "<meta name='viewport' content='width=device-width' />" +
                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                "<title>Orden de Compra</title>" +
                "<style>" +
                "/* -------------------------------------" +
                "GLOBAL RESETS" +
                "------------------------------------- */" +
                "" +
                "/*All the styling goes here*/" +
                "" +
                "img {" +
                "border: none;" +
                "-ms-interpolation-mode: bicubic;" +
                "max-width: 100%;" +
                "}" +
                "" +
                "body {" +
                "background-color: #f6f6f6;" +
                "font-family: sans-serif;" +
                "-webkit-font-smoothing: antialiased;" +
                "font-size: 14px;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "padding: 0;" +
                "-ms-text-size-adjust: 100%;" +
                "-webkit-text-size-adjust: 100%;" +
                "}" +
                "" +
                "table {" +
                "border-collapse: separate;" +
                "mso-table-lspace: 0pt;" +
                "mso-table-rspace: 0pt;" +
                "width: 100%; }" +
                "table td {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "vertical-align: top;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BODY & CONTAINER" +
                "------------------------------------- */" +
                "" +
                ".body {" +
                "background-color: #f6f6f6;" +
                "width: 100%;" +
                "}" +
                "" +
                "/* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */" +
                ".container {" +
                "display: block;" +
                "Margin: 0 auto !important;" +
                "/* makes it centered */" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "width: 580px;" +
                "}" +
                "" +
                "/* This should also be a block element, so that it will fill 100% of the .container */" +
                ".content {" +
                "box-sizing: border-box;" +
                "display: block;" +
                "Margin: 0 auto;" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "HEADER, FOOTER, MAIN" +
                "------------------------------------- */" +
                ".main {" +
                "background: #ffffff;" +
                "border-radius: 3px;" +
                "width: 100%;" +
                "}" +
                "" +
                ".wrapper {" +
                "box-sizing: border-box;" +
                "padding: 20px;" +
                "}" +
                "" +
                ".content-block {" +
                "padding-bottom: 10px;" +
                "padding-top: 10px;" +
                "}" +
                "" +
                ".footer {" +
                "clear: both;" +
                "Margin-top: 10px;" +
                "text-align: center;" +
                "width: 100%;" +
                "}" +
                ".footer td," +
                ".footer p," +
                ".footer span," +
                ".footer a {" +
                "color: #999999;" +
                "font-size: 12px;" +
                "text-align: center;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "TYPOGRAPHY" +
                "------------------------------------- */" +
                "h1," +
                "h2," +
                "h3," +
                "h4 {" +
                "color: #000000;" +
                "font-family: sans-serif;" +
                "font-weight: 400;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "margin-bottom: 30px;" +
                "}" +
                "" +
                "h1 {" +
                "font-size: 35px;" +
                "font-weight: 300;" +
                "text-align: center;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                "p," +
                "ul," +
                "ol {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "font-weight: normal;" +
                "margin: 0;" +
                "margin-bottom: 15px;" +
                "}" +
                "p li," +
                "ul li," +
                "ol li {" +
                "list-style-position: inside;" +
                "margin-left: 5px;" +
                "}" +
                "" +
                "a {" +
                "color: #3498db;" +
                "text-decoration: underline;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BUTTONS" +
                "------------------------------------- */" +
                ".btn {" +
                "box-sizing: border-box;" +
                "width: 100%; }" +
                ".btn > tbody > tr > td {" +
                "padding-bottom: 15px; }" +
                ".btn table {" +
                "width: auto;" +
                "}" +
                ".btn table td {" +
                "background-color: #ffffff;" +
                "border-radius: 5px;" +
                "text-align: center;" +
                "}" +
                ".btn a {" +
                "background-color: #ffffff;" +
                "border: solid 1px #3498db;" +
                "border-radius: 5px;" +
                "box-sizing: border-box;" +
                "color: #3498db;" +
                "cursor: pointer;" +
                "display: inline-block;" +
                "font-size: 14px;" +
                "font-weight: bold;" +
                "margin: 0;" +
                "padding: 12px 25px;" +
                "text-decoration: none;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                ".btn-primary table td {" +
                "background-color: #3498db;" +
                "}" +
                "" +
                ".btn-primary a {" +
                "background-color: #3498db;" +
                "border-color: #3498db;" +
                "color: #ffffff;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "OTHER STYLES THAT MIGHT BE USEFUL" +
                "------------------------------------- */" +
                ".last {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".first {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".align-center {" +
                "text-align: center;" +
                "}" +
                "" +
                ".align-right {" +
                "text-align: right;" +
                "}" +
                "" +
                ".align-left {" +
                "text-align: left;" +
                "}" +
                "" +
                ".clear {" +
                "clear: both;" +
                "}" +
                "" +
                ".mt0 {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".mb0 {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".preheader {" +
                "color: transparent;" +
                "display: none;" +
                "height: 0;" +
                "max-height: 0;" +
                "max-width: 0;" +
                "opacity: 0;" +
                "overflow: hidden;" +
                "mso-hide: all;" +
                "visibility: hidden;" +
                "width: 0;" +
                "}" +
                "" +
                ".powered-by a {" +
                "text-decoration: none;" +
                "}" +
                "" +
                "hr {" +
                "border: 0;" +
                "border-bottom: 1px solid #f6f6f6;" +
                "Margin: 20px 0;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "RESPONSIVE AND MOBILE FRIENDLY STYLES" +
                "------------------------------------- */" +
                "@media only screen and (max-width: 620px) {" +
                "table[class=body] h1 {" +
                "font-size: 28px !important;" +
                "margin-bottom: 10px !important;" +
                "}" +
                "table[class=body] p," +
                "table[class=body] ul," +
                "table[class=body] ol," +
                "table[class=body] td," +
                "table[class=body] span," +
                "table[class=body] a {" +
                "font-size: 16px !important;" +
                "}" +
                "table[class=body] .wrapper," +
                "table[class=body] .article {" +
                "padding: 10px !important;" +
                "}" +
                "table[class=body] .content {" +
                "padding: 0 !important;" +
                "}" +
                "table[class=body] .container {" +
                "padding: 0 !important;" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .main {" +
                "border-left-width: 0 !important;" +
                "border-radius: 0 !important;" +
                "border-right-width: 0 !important;" +
                "}" +
                "table[class=body] .btn table {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .btn a {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .img-responsive {" +
                "height: auto !important;" +
                "max-width: 100% !important;" +
                "width: auto !important;" +
                "}" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "PRESERVE THESE STYLES IN THE HEAD" +
                "------------------------------------- */" +
                "@media all {" +
                ".ExternalClass {" +
                "width: 100%;" +
                "}" +
                ".ExternalClass," +
                ".ExternalClass p," +
                ".ExternalClass span," +
                ".ExternalClass font," +
                ".ExternalClass td," +
                ".ExternalClass div {" +
                "line-height: 100%;" +
                "}" +
                ".apple-link a {" +
                "color: inherit !important;" +
                "font-family: inherit !important;" +
                "font-size: inherit !important;" +
                "font-weight: inherit !important;" +
                "line-height: inherit !important;" +
                "text-decoration: none !important;" +
                "}" +
                ".btn-primary table td:hover {" +
                "background-color: #34495e !important;" +
                "}" +
                ".btn-primary a:hover {" +
                "background-color: #34495e !important;" +
                "border-color: #34495e !important;" +
                "}" +
                "}" +
                "" +
                "</style>" +
                "</head>" +
                "<body class=''>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body'>" +
                "<tr>" +
                "<td>&nbsp;</td>" +
                "<td class='container'>" +
                "<div class='content'>" +
                "" +
                "<!-- START CENTERED WHITE CONTAINER -->" +
                "<span class='preheader'>Estimad@, '" + solicitante.nombre_completo + @"'. Se rechazo la orden de compra por SubGerencia.</span>" +
                "<table role='presentation' class='main'>" +
                "" +
                "<!-- START MAIN CONTENT AREA -->" +
                "<tr>" +
                "<td class='wrapper'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td>" +
                "<p>Estimad@ " + solicitante.nombre_completo + ",</p>" +
                "<p>La Orden de Compra Nro: " + orden.codigo_orden + " donde se incluyo articulos de la solicitud de compra Nro:" + n.codigo_solicitud + " que fue creada por usted. Ha sido rechazada, por el siguiente motivo: " + orden.motivo_autorizacion_subgerencia + ".</p>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='btn btn-primary'>" +
                "<tbody>" +
                "<tr>" +
                "<td align='left'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tbody>" +
                "<tr>" +
                "<td> <a class='btn-primary' href='" + url + "solicitud/detail/" + n.codigo_solicitud + @"' target='_blank'>Abrir Solicitud</a> </td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<p>Si tiene problemas al abrir esta solicitud directamente. Puede ingresar a <a href='http://intranet.lafar.net' target='_blank'>http://intranet.lafar.net</a>. Ingrese a la Aplicación Sistema de Compras y verifique su listado de solicitudes " +
                "<p>En otro caso comuniquese con el área de Sistemas LAFAR.</p>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "" +
                "<!-- END MAIN CONTENT AREA -->" +
                "</table>" +
                "" +
                "<!-- START FOOTER -->" +
                "<div class='footer'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td class='content-block'>" +
                "<span class='apple-link'>LABORATORIOS FARMACEUTICOS LAFAR S.A., Calle Luis Crespo # 2213 Zona de Sopocachi</span>" +
                "<br> Puede visitarnos a la pagina web <a href='http://www.lafar.net'>http://www.lafar.net</a>." +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td class='content-block powered-by'>" +
                "" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</div>" +
                "<!-- END FOOTER -->" +
                "" +
                "<!-- END CENTERED WHITE CONTAINER -->" +
                "</div>" +
                "</td>" +
                "<td>&nbsp;</td>" +
                "</tr>" +
                "</table>" +
                "</body>" +
                "</html>" +
                "";
            return body;
        }


        public string bodyEmailAprobarOrden(SCUsuarios solicitante, NotificacionOrden n, OCOrdenCompra orden)
        {
            string body = "<!doctype html>" +
                "<html>" +
                "<head>" +
                "<meta name='viewport' content='width=device-width' />" +
                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                "<title>Orden de Compra</title>" +
                "<style>" +
                "/* -------------------------------------" +
                "GLOBAL RESETS" +
                "------------------------------------- */" +
                "" +
                "/*All the styling goes here*/" +
                "" +
                "img {" +
                "border: none;" +
                "-ms-interpolation-mode: bicubic;" +
                "max-width: 100%;" +
                "}" +
                "" +
                "body {" +
                "background-color: #f6f6f6;" +
                "font-family: sans-serif;" +
                "-webkit-font-smoothing: antialiased;" +
                "font-size: 14px;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "padding: 0;" +
                "-ms-text-size-adjust: 100%;" +
                "-webkit-text-size-adjust: 100%;" +
                "}" +
                "" +
                "table {" +
                "border-collapse: separate;" +
                "mso-table-lspace: 0pt;" +
                "mso-table-rspace: 0pt;" +
                "width: 100%; }" +
                "table td {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "vertical-align: top;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BODY & CONTAINER" +
                "------------------------------------- */" +
                "" +
                ".body {" +
                "background-color: #f6f6f6;" +
                "width: 100%;" +
                "}" +
                "" +
                "/* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */" +
                ".container {" +
                "display: block;" +
                "Margin: 0 auto !important;" +
                "/* makes it centered */" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "width: 580px;" +
                "}" +
                "" +
                "/* This should also be a block element, so that it will fill 100% of the .container */" +
                ".content {" +
                "box-sizing: border-box;" +
                "display: block;" +
                "Margin: 0 auto;" +
                "max-width: 580px;" +
                "padding: 10px;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "HEADER, FOOTER, MAIN" +
                "------------------------------------- */" +
                ".main {" +
                "background: #ffffff;" +
                "border-radius: 3px;" +
                "width: 100%;" +
                "}" +
                "" +
                ".wrapper {" +
                "box-sizing: border-box;" +
                "padding: 20px;" +
                "}" +
                "" +
                ".content-block {" +
                "padding-bottom: 10px;" +
                "padding-top: 10px;" +
                "}" +
                "" +
                ".footer {" +
                "clear: both;" +
                "Margin-top: 10px;" +
                "text-align: center;" +
                "width: 100%;" +
                "}" +
                ".footer td," +
                ".footer p," +
                ".footer span," +
                ".footer a {" +
                "color: #999999;" +
                "font-size: 12px;" +
                "text-align: center;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "TYPOGRAPHY" +
                "------------------------------------- */" +
                "h1," +
                "h2," +
                "h3," +
                "h4 {" +
                "color: #000000;" +
                "font-family: sans-serif;" +
                "font-weight: 400;" +
                "line-height: 1.4;" +
                "margin: 0;" +
                "margin-bottom: 30px;" +
                "}" +
                "" +
                "h1 {" +
                "font-size: 35px;" +
                "font-weight: 300;" +
                "text-align: center;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                "p," +
                "ul," +
                "ol {" +
                "font-family: sans-serif;" +
                "font-size: 14px;" +
                "font-weight: normal;" +
                "margin: 0;" +
                "margin-bottom: 15px;" +
                "}" +
                "p li," +
                "ul li," +
                "ol li {" +
                "list-style-position: inside;" +
                "margin-left: 5px;" +
                "}" +
                "" +
                "a {" +
                "color: #3498db;" +
                "text-decoration: underline;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "BUTTONS" +
                "------------------------------------- */" +
                ".btn {" +
                "box-sizing: border-box;" +
                "width: 100%; }" +
                ".btn > tbody > tr > td {" +
                "padding-bottom: 15px; }" +
                ".btn table {" +
                "width: auto;" +
                "}" +
                ".btn table td {" +
                "background-color: #ffffff;" +
                "border-radius: 5px;" +
                "text-align: center;" +
                "}" +
                ".btn a {" +
                "background-color: #ffffff;" +
                "border: solid 1px #3498db;" +
                "border-radius: 5px;" +
                "box-sizing: border-box;" +
                "color: #3498db;" +
                "cursor: pointer;" +
                "display: inline-block;" +
                "font-size: 14px;" +
                "font-weight: bold;" +
                "margin: 0;" +
                "padding: 12px 25px;" +
                "text-decoration: none;" +
                "text-transform: capitalize;" +
                "}" +
                "" +
                ".btn-primary table td {" +
                "background-color: #3498db;" +
                "}" +
                "" +
                ".btn-primary a {" +
                "background-color: #3498db;" +
                "border-color: #3498db;" +
                "color: #ffffff;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "OTHER STYLES THAT MIGHT BE USEFUL" +
                "------------------------------------- */" +
                ".last {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".first {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".align-center {" +
                "text-align: center;" +
                "}" +
                "" +
                ".align-right {" +
                "text-align: right;" +
                "}" +
                "" +
                ".align-left {" +
                "text-align: left;" +
                "}" +
                "" +
                ".clear {" +
                "clear: both;" +
                "}" +
                "" +
                ".mt0 {" +
                "margin-top: 0;" +
                "}" +
                "" +
                ".mb0 {" +
                "margin-bottom: 0;" +
                "}" +
                "" +
                ".preheader {" +
                "color: transparent;" +
                "display: none;" +
                "height: 0;" +
                "max-height: 0;" +
                "max-width: 0;" +
                "opacity: 0;" +
                "overflow: hidden;" +
                "mso-hide: all;" +
                "visibility: hidden;" +
                "width: 0;" +
                "}" +
                "" +
                ".powered-by a {" +
                "text-decoration: none;" +
                "}" +
                "" +
                "hr {" +
                "border: 0;" +
                "border-bottom: 1px solid #f6f6f6;" +
                "Margin: 20px 0;" +
                "}" +
                "" +
                "/* -------------------------------------" +
                "RESPONSIVE AND MOBILE FRIENDLY STYLES" +
                "------------------------------------- */" +
                "@media only screen and (max-width: 620px) {" +
                "table[class=body] h1 {" +
                "font-size: 28px !important;" +
                "margin-bottom: 10px !important;" +
                "}" +
                "table[class=body] p," +
                "table[class=body] ul," +
                "table[class=body] ol," +
                "table[class=body] td," +
                "table[class=body] span," +
                "table[class=body] a {" +
                "font-size: 16px !important;" +
                "}" +
                "table[class=body] .wrapper," +
                "table[class=body] .article {" +
                "padding: 10px !important;" +
                "}" +
                "table[class=body] .content {" +
                "padding: 0 !important;" +
                "}" +
                "table[class=body] .container {" +
                "padding: 0 !important;" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .main {" +
                "border-left-width: 0 !important;" +
                "border-radius: 0 !important;" +
                "border-right-width: 0 !important;" +
                "}" +
                "table[class=body] .btn table {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .btn a {" +
                "width: 100% !important;" +
                "}" +
                "table[class=body] .img-responsive {" +
                "height: auto !important;" +
                "max-width: 100% !important;" +
                "width: auto !important;" +
                "}" +
                "}" +
                "" +
                "/* -------------------------------------" + 
                "PRESERVE THESE STYLES IN THE HEAD" +
                "------------------------------------- */" +
                "@media all {" +
                ".ExternalClass {" +
                "width: 100%;" +
                "}" +
                ".ExternalClass," +
                ".ExternalClass p," +
                ".ExternalClass span," +
                ".ExternalClass font," +
                ".ExternalClass td," +
                ".ExternalClass div {" +
                "line-height: 100%;" +
                "}" +
                ".apple-link a {" +
                "color: inherit !important;" +
                "font-family: inherit !important;" + 
                "font-size: inherit !important;" + 
                "font-weight: inherit !important;" +
                "line-height: inherit !important;" +
                "text-decoration: none !important;" +
                "}" +
                ".btn-primary table td:hover {" +
                "background-color: #34495e !important;" +
                "}" +
                ".btn-primary a:hover {" +
                "background-color: #34495e !important;" +
                "border-color: #34495e !important;" +
                "}" +
                "}" +
                "" +
                "</style>" +
                "</head>" +
                "<body class=''>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body'>" +
                "<tr>" +
                "<td>&nbsp;</td>" +
                "<td class='container'>" +
                "<div class='content'>" +
                "" + 
                "<!-- START CENTERED WHITE CONTAINER -->" +
                "<span class='preheader'>Estimad@, '" + solicitante.nombre_completo + @"'. Se aprobo la orden de compra Nro: "+ orden.codigo_orden +".</span>" + 
                "<table role='presentation' class='main'>" + 
                "" +
                "<!-- START MAIN CONTENT AREA -->" +
                "<tr>" +
                "<td class='wrapper'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td>" +
                "<p>Estimad@ " + solicitante.nombre_completo + ",</p>" +
                "<p>La Orden de Compra Nro: " + orden.codigo_orden + " donde se incluyo articulos de la solicitud de compra Nro:" + n.codigo_solicitud + " que fue creada por usted. Ha sido aprobada.</p>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='btn btn-primary'>" +
                "<tbody>" +
                "<tr>" +
                "<td align='left'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tbody>" +
                "<tr>" +
                "<td> <a class='btn-primary' href='" + url + "solicitud/detail/" + n.codigo_solicitud + @"' target='_blank'>Abrir Solicitud</a> </td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<p>Si tiene problemas al abrir esta solicitud directamente. Puede ingresar a <a href='http://intranet.lafar.net' target='_blank'>http://intranet.lafar.net</a>. Ingrese a la Aplicación Sistema de Compras y verifique su listado de solicitudes " +
                "<p>En otro caso comuniquese con el área de Sistemas LAFAR.</p>" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</td>" +
                "</tr>" +
                "" +
                "<!-- END MAIN CONTENT AREA -->" +
                "</table>" +
                "" +
                "<!-- START FOOTER -->" +
                "<div class='footer'>" +
                "<table role='presentation' border='0' cellpadding='0' cellspacing='0'>" +
                "<tr>" +
                "<td class='content-block'>" +
                "<span class='apple-link'>LABORATORIOS FARMACEUTICOS LAFAR S.A., Calle Luis Crespo # 2213 Zona de Sopocachi</span>" +
                "<br> Puede visitarnos a la pagina web <a href='http://www.lafar.net'>http://www.lafar.net</a>." +
                "</td>" +
                "</tr>" +
                "<tr>" +
                "<td class='content-block powered-by'>" +
                "" +
                "</td>" +
                "</tr>" +
                "</table>" +
                "</div>" +
                "<!-- END FOOTER -->" +
                "" +
                "<!-- END CENTERED WHITE CONTAINER -->" +
                "</div>" +
                "</td>" +
                "<td>&nbsp;</td>" +
                "</tr>" +
                "</table>" +
                "</body>" +
                "</html>" +
                "";
            return body;
        }
    }
}
