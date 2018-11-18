using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using CapaModelos;
using CapaNegocio;

namespace Reportes
{
    public class CertificadoMP
    {
        BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        iTextSharp.text.Font font12;
        iTextSharp.text.Font font11;
        iTextSharp.text.Font font10;
        iTextSharp.text.Font font10b;
        iTextSharp.text.Font font10bn;

        public CertificadoMP()
        {
            font12 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            font11 = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
            font10 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            font10b = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            font10bn = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);
        }

        public void Crear(CertificadoMPModelo certificado, List<CaracteristicaCertificadoModelo> lcf, List<CaracteristicaCertificadoModelo> lcm)
        {
            string appRootDir = Parametros.rutaCertificadoMP();//HttpContext.Current.Server.MapPath("~/certificadosmp/"); //new DirectoryInfo(Environment.SystemDirectory).Parent.FullName;
            try
            {
                // Step 1: Creating System.IO.FileStream object
                using (FileStream fs = new FileStream(appRootDir + certificado.codigo_certificado +".pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                // Step 2: Creating iTextSharp.text.Document object
                using (Document doc = new Document(PageSize.LEGAL, 25f, 25f, 90f, 0f))
                // Step 3: Creating iTextSharp.text.pdf.PdfWriter object
                // It helps to write the Document to the Specified FileStream
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    writer.PageEvent = new HeaderFooter(certificado.tipo_clasificacion_producto);
                    // Step 4: Openning the Document
                    doc.Open();

                    #region CABECERA DEL REPORTE DE MATERIA PRIMA

                    PdfPTable tblformp = new PdfPTable(5);
                    tblformp.SpacingBefore = 0f;
                    tblformp.SpacingAfter = 4f;
                    float[] widths_tf = new float[] { 1.25f, 1.25f, 2f, 1.25f, 1.25f };
                    tblformp.SetWidths(widths_tf);
                    tblformp.WidthPercentage = 100f;

                    PdfPCell cvaciofor = new PdfPCell(new Paragraph(""));
                    cvaciofor.Colspan = 4;
                    cvaciofor.Border = 0;
                    cvaciofor.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblformp.AddCell(cvaciofor);
                    PdfPCell cfor = new PdfPCell(new Paragraph("FOR811202", this.font11));
                    cfor.Border = 0;
                    cfor.HorizontalAlignment = Element.ALIGN_CENTER;
                    tblformp.AddCell(cfor);
                    doc.Add(tblformp);

                    PdfPTable tprotocolo = new PdfPTable(5);
                    tprotocolo.SpacingBefore = 0f;
                    tprotocolo.SpacingAfter = 2f;
                    float[] widths_tp = new float[] { 1.25F, 1.25F, 2f, 1.25f, 1.25f };
                    tprotocolo.SetWidths(widths_tp);
                    tprotocolo.WidthPercentage = 100f;

                    PdfPCell cvacio = new PdfPCell(new Paragraph("", this.font10b));
                    cvacio.Colspan = 3;
                    cvacio.Border = 0;
                    cvacio.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tprotocolo.AddCell(cvacio);
                    PdfPCell cprotocolo = new PdfPCell(new Paragraph("PROTOCOLO:", this.font10b));
                    cprotocolo.Border = 0;
                    cprotocolo.HorizontalAlignment = Element.ALIGN_CENTER;
                    tprotocolo.AddCell(cprotocolo);
                    PdfPCell cnprotocolo = new PdfPCell(new Paragraph(certificado.protocolo, this.font10));
                    cnprotocolo.HorizontalAlignment = Element.ALIGN_CENTER;
                    tprotocolo.AddCell(cnprotocolo);
                    doc.Add(tprotocolo);



                    PdfPTable tblcabecera = new PdfPTable(2);
                    float[] widths_tb = new float[] { 2f, 4f };
                    tblcabecera.SetWidths(widths_tb);
                    tblformp.SpacingBefore = 0f;
                    tblformp.SpacingAfter = 6f;
                    tblcabecera.WidthPercentage = 100;

                    PdfPCell cnombreprd = new PdfPCell(new Paragraph("Nombre del Producto", this.font10b));
                    cnombreprd.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(cnombreprd);
                    PdfPCell nomproducto = new PdfPCell(new Paragraph(certificado.nombre_producto, this.font10));
                    nomproducto.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(nomproducto);

                    PdfPCell cnlote = new PdfPCell(new Paragraph("Nro. de Lote", this.font10b));
                    cnlote.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(cnlote);
                    PdfPCell lote = new PdfPCell(new Paragraph(certificado.lote, this.font10));
                    lote.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(lote);

                    PdfPCell cfabricacion = new PdfPCell(new Paragraph("Fecha de Fabricación", this.font10b));
                    cfabricacion.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(cfabricacion);
                    PdfPCell fecfabricacion = new PdfPCell(new Paragraph(certificado.fecha_fabricacion.ToShortDateString(), this.font10));
                    fecfabricacion.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(fecfabricacion);

                    PdfPCell cvencimiento = new PdfPCell(new Paragraph("Fecha de Vencimiento", this.font10b));
                    cvencimiento.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(cvencimiento);
                    PdfPCell fecvencimiento = new PdfPCell(new Paragraph(certificado.fecha_vencimiento.ToShortDateString(), this.font10));
                    fecvencimiento.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(fecvencimiento);

                    PdfPCell cproveedor = new PdfPCell(new Paragraph("Nombre del Proveedor", this.font10b));
                    cproveedor.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(cproveedor);
                    PdfPCell nomproveedor = new PdfPCell(new Paragraph(certificado.nombre_proveedor, this.font10));
                    nomproveedor.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcabecera.AddCell(nomproveedor);

                    if (certificado.nombre_fabricante != "") { 
                        PdfPCell cfabricante = new PdfPCell(new Paragraph("Fabricante", this.font10b));
                        cfabricante.HorizontalAlignment = Element.ALIGN_LEFT;
                        tblcabecera.AddCell(cfabricante);
                        PdfPCell nomfabricante = new PdfPCell(new Paragraph(certificado.nombre_fabricante, this.font10));
                        nomfabricante.HorizontalAlignment = Element.ALIGN_LEFT;
                        tblcabecera.AddCell(nomfabricante);
                    }

                    doc.Add(tblcabecera);

                    #endregion

                    #region CUERPO DEL REPORTE DE MATERIA PRIMA

                    PdfPTable tcuerpo = new PdfPTable(3);
                    tcuerpo.SpacingBefore = 3f;
                    tcuerpo.SpacingAfter = 2f;
                    //float[] widths_tcp = new float[] { 1.25F, 1.25F, 2f, 1.25f, 1.25f };
                    //tcuerpo.SetWidths(widths_tcp);
                    tcuerpo.WidthPercentage = 100f;
                    //tcabecera.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                    PdfPCell censayo = new PdfPCell(new Paragraph("ENSAYO", this.font10bn));
                    censayo.BorderColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    censayo.BorderColor = BaseColor.LIGHT_GRAY;
                    censayo.BorderColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    censayo.BackgroundColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    censayo.BackgroundColor = BaseColor.BLACK;
                    censayo.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.BLACK;
                    censayo.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcuerpo.AddCell(censayo);
                    PdfPCell cespecificaciones = new PdfPCell(new Paragraph("ESPECIFICACIONES", this.font10bn));
                    cespecificaciones.BorderColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    cespecificaciones.BorderColor = BaseColor.LIGHT_GRAY;
                    cespecificaciones.BorderColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    cespecificaciones.BackgroundColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    cespecificaciones.BackgroundColor = BaseColor.BLACK;
                    cespecificaciones.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.BLACK;
                    cespecificaciones.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcuerpo.AddCell(cespecificaciones);
                    PdfPCell cresultado = new PdfPCell(new Paragraph("RESULTADO", this.font10bn));
                    cresultado.BorderColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    cresultado.BorderColor = BaseColor.LIGHT_GRAY;
                    cresultado.BorderColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    cresultado.BackgroundColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    cresultado.BackgroundColor = BaseColor.BLACK;
                    cresultado.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.BLACK;
                    cresultado.HorizontalAlignment = Element.ALIGN_CENTER;
                    tcuerpo.AddCell(cresultado);
                    PdfPCell ccfisicas = new PdfPCell(new Paragraph("CARACTERÍSTICAS FÍSICAS", this.font10bn));
                    ccfisicas.Colspan = 3;
                    ccfisicas.BorderColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    ccfisicas.BorderColor = BaseColor.LIGHT_GRAY;
                    ccfisicas.BorderColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    ccfisicas.BackgroundColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    ccfisicas.BackgroundColor = BaseColor.BLACK;
                    ccfisicas.BackgroundColor = iTextSharp.text.pdf.ExtendedColor.BLACK;
                    ccfisicas.HorizontalAlignment = Element.ALIGN_LEFT;
                    tcuerpo.AddCell(ccfisicas);
                    doc.Add(tcuerpo);

                    PdfPTable tbldatosfis = new PdfPTable(3);
                    tbldatosfis.SpacingAfter = 0f;
                    tbldatosfis.SpacingAfter = 2f;
                    tbldatosfis.WidthPercentage = 100;

                     foreach (var item in lcf)
                    {

                        PdfPCell celdatosfis = new PdfPCell(new Paragraph(item.id_caracteristica, this.font10b));
                        celdatosfis.HorizontalAlignment = Element.ALIGN_LEFT;
                        tbldatosfis.AddCell(celdatosfis);
                        PdfPCell celdatosfisa1 = new PdfPCell(new Paragraph(item.especificacion, this.font10));
                        celdatosfisa1.HorizontalAlignment = Element.ALIGN_CENTER;
                        tbldatosfis.AddCell(celdatosfisa1);
                        PdfPCell celdatosfisa2 = new PdfPCell(new Paragraph(item.resultado, this.font10));
                        celdatosfisa2.HorizontalAlignment = Element.ALIGN_CENTER;
                        tbldatosfis.AddCell(celdatosfisa2);
                    }
                        doc.Add(tbldatosfis);
                    
                    Paragraph saltoDeLinea = new Paragraph(" ");
                    doc.Add(saltoDeLinea);

                    PdfPTable tblcmicrobio = new PdfPTable(3);
                    tblcmicrobio.SpacingAfter = 0f;
                    tblcmicrobio.SpacingBefore = 2f;
                    tblcmicrobio.WidthPercentage = 100;
                    tblcmicrobio.DefaultCell.BackgroundColor = BaseColor.BLACK;
                    PdfPCell cconmicro = new PdfPCell(new Paragraph("CONTROL MICROBIOLÓGICO", this.font10bn));
                    cconmicro.Colspan = 3;
                    cconmicro.BorderColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    cconmicro.BorderColor = BaseColor.LIGHT_GRAY;
                    cconmicro.BorderColor = iTextSharp.text.pdf.ExtendedColor.LIGHT_GRAY;
                    cconmicro.BackgroundColor = new iTextSharp.text.BaseColor(104, 104, 104);
                    cconmicro.BackgroundColor = BaseColor.BLACK;
                    cconmicro.HorizontalAlignment = Element.ALIGN_LEFT;
                    tblcmicrobio.AddCell(cconmicro);
                    doc.Add(tblcmicrobio);

                    PdfPTable tbldatosmbio = new PdfPTable(3);
                    tbldatosmbio.SpacingAfter = 0f;
                    tbldatosmbio.SpacingBefore = 2f;
                    tbldatosmbio.WidthPercentage = 100;

                     foreach (var item in lcm)
                    {
                        PdfPCell celdatosmbio = new PdfPCell(new Paragraph(item.id_caracteristica, this.font10b));
                        celdatosmbio.HorizontalAlignment = Element.ALIGN_LEFT;
                        tbldatosmbio.AddCell(celdatosmbio);
                        PdfPCell celdatosmca1 = new PdfPCell(new Paragraph(item.especificacion, this.font10));
                        celdatosmca1.HorizontalAlignment = Element.ALIGN_CENTER;
                        tbldatosmbio.AddCell(celdatosmca1);
                        PdfPCell celdatosmca2 = new PdfPCell(new Paragraph(item.resultado, this.font10));
                        celdatosmca2.HorizontalAlignment = Element.ALIGN_CENTER;
                        tbldatosmbio.AddCell(celdatosmca2);
                    }
                        doc.Add(tbldatosmbio);
                   
                    Paragraph saltoDeLinea1 = new Paragraph(" ");
                    doc.Add(saltoDeLinea1);

                    PdfPTable tblconservacion = new PdfPTable(3);
                    tblconservacion.SpacingAfter = 0f;
                    tblconservacion.SpacingBefore = 2f;
                    tblconservacion.WidthPercentage = 100;
                    PdfPCell celdapres = new PdfPCell(new Paragraph("CONSERVACIÓN Y ALAMACENAMIENTO", this.font10b));
                    celdapres.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdapres.Colspan = 3;
                    tblconservacion.AddCell(celdapres);
                    PdfPCell celdacon = new PdfPCell(new Paragraph(certificado.conservacionyalm, this.font10));
                    celdacon.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdacon.Colspan = 3;
                    celdacon.Padding = 10;
                    //celdapresna.Rowspan = 2;
                    tblconservacion.AddCell(celdacon);
                    doc.Add(tblconservacion);

                    PdfPTable tblreferencias = new PdfPTable(3);
                    tblreferencias.SpacingAfter = 2f;
                    tblreferencias.SpacingBefore = 2f;
                    tblreferencias.WidthPercentage = 100;
                    PdfPCell celdaref = new PdfPCell(new Paragraph("REFERENCIAS", this.font10b));
                    celdaref.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdaref.Colspan = 3;
                    tblreferencias.AddCell(celdaref);
                    PdfPCell celdacona = new PdfPCell(new Paragraph(certificado.referencias, this.font10));
                    celdacona.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdacona.Colspan = 3;
                    celdacona.Padding = 10;
                    tblreferencias.AddCell(celdacona);
                    doc.Add(tblreferencias);

                    PdfPTable tblobservaciones = new PdfPTable(3);
                    tblobservaciones.SpacingAfter = 60f;
                    tblobservaciones.SpacingBefore = 2f;
                    tblobservaciones.WidthPercentage = 100;
                    PdfPCell celdaobs = new PdfPCell(new Paragraph("OBSERVACIÓN", this.font10b));
                    celdaobs.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdaobs.Colspan = 3;
                    tblobservaciones.AddCell(celdaobs);
                    PdfPCell celdaobsna = new PdfPCell(new Paragraph(certificado.observaciones, this.font10));
                    celdaobsna.HorizontalAlignment = Element.ALIGN_LEFT;
                    celdaobsna.Colspan = 3;
                    celdaobsna.Padding = 10;
                    tblobservaciones.AddCell(celdaobsna);
                    doc.Add(tblobservaciones);


                   /* PdfPTable tbldictamen = new PdfPTable(3);
                    tbldictamen.SpacingBefore = 40f;
                    tbldictamen.WidthPercentage = 100;
                    PdfPCell celdadic = new PdfPCell(new Paragraph("DICTAMEN", this.font10b));
                    celdadic.HorizontalAlignment = Element.ALIGN_CENTER;
                    tbldictamen.AddCell(celdadic);
                    PdfPCell celdaanalista = new PdfPCell(new Paragraph("ANALISTA", this.font10b));
                    celdaanalista.HorizontalAlignment = Element.ALIGN_CENTER;
                    tbldictamen.AddCell(celdaanalista);
                    PdfPCell celdajefe = new PdfPCell(new Paragraph("JEFE CONTROL DE CALIDAD", this.font10b));
                    celdajefe.HorizontalAlignment = Element.ALIGN_CENTER;
                    tbldictamen.AddCell(celdajefe);


                    PdfPCell celsello = new PdfPCell(new Paragraph("sello dictamen", this.font10b));
                    celsello.Rowspan = 6;
                    celsello.HorizontalAlignment = Element.ALIGN_CENTER;
                    //celsello.Padding = 50f;
                    tbldictamen.AddCell(celsello);

                    PdfPCell celselloana = new PdfPCell(new Paragraph("sello analista"));
                    celselloana.Rowspan = 5;
                    celselloana.HorizontalAlignment = Element.ALIGN_CENTER;
                    //celselloana.Padding = 40f;
                    //celselloana.Rowspan = 4;
                    tbldictamen.AddCell(celselloana);

                    string fecha = certificado.fecha_analisis.ToShortDateString();
                    DateTime fechar = DateTime.Parse(fecha.Split(' ')[0]);

                    PdfPCell celfecha = new PdfPCell(new Paragraph("FECHA:" + fecha, this.font10b));
                    celfecha.HorizontalAlignment = Element.ALIGN_CENTER;
                    tbldictamen.AddCell(celfecha);

                    PdfPCell celsellojefe = new PdfPCell(new Paragraph("sello jefe de control"));
                    celsellojefe.Rowspan = 2;
                    celsellojefe.HorizontalAlignment = Element.ALIGN_CENTER;
                    celsellojefe.Padding = 20f;
                    tbldictamen.AddCell(celsellojefe);
                    PdfPCell celdirtec = new PdfPCell(new Paragraph("VoBo DIRECTOR TÉCNICO", this.font10b));
                    celdirtec.HorizontalAlignment = Element.ALIGN_CENTER;
                    tbldictamen.AddCell(celdirtec);
                    PdfPCell celsellodirtec = new PdfPCell(new Paragraph("sello de director"));
                    celsellodirtec.Rowspan = 3;
                    celsellodirtec.HorizontalAlignment = Element.ALIGN_CENTER;
                    celsellodirtec.Padding = 20f;
                    tbldictamen.AddCell(celsellodirtec);

                    doc.Add(tbldictamen);*/

                    #endregion

                    #region DICTAMEN PIE DE FIRMA
                    PdfContentByte cb = writer.DirectContent;

                    PdfPTable tbldictamen = new PdfPTable(3);

                    tbldictamen.WidthPercentage = 100;

                    PdfPCell cdictamen = new PdfPCell(new Paragraph("DICTAMEN", font10b));
                    cdictamen.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell canalista = new PdfPCell(new Paragraph("ANALISTA", font10b));
                    canalista.HorizontalAlignment = Element.ALIGN_CENTER;
                    PdfPCell cjefe = new PdfPCell(new Paragraph("JEFE CONTROL CALIDAD", font10b));
                    cjefe.HorizontalAlignment = Element.ALIGN_CENTER;

                    tbldictamen.AddCell(cdictamen);
                    tbldictamen.AddCell(canalista);
                    tbldictamen.AddCell(cjefe);

                    Image aprobado = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/aprobado.png"));
                    Image rechazado = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/rechazado.png"));

                    float percentage = 0.0f;
                    percentage = 100 / rechazado.Width;
                    rechazado.ScalePercent(percentage * 120);
                    aprobado.ScalePercent(percentage * 120);

                    PdfPCell c11;
                    if (certificado.dictamen == "APROBADO")
                    {
                        c11 = new PdfPCell(aprobado);
                    }
                    else
                    {
                        c11 = new PdfPCell(rechazado);
                    }
                    c11.HorizontalAlignment = Element.ALIGN_CENTER;
                    c11.VerticalAlignment = Element.ALIGN_MIDDLE;
                    c11.Rowspan = 4;

                    PdfPCell c12 = new PdfPCell(new Paragraph(certificado.codigo_analista + "\r\n" + "FECHA: " + certificado.fecha_analisis.ToShortDateString(), font10b));
                    c12.VerticalAlignment = Element.ALIGN_BOTTOM;
                    c12.HorizontalAlignment = Element.ALIGN_CENTER;
                    c12.Rowspan = 4;

                    PdfPCell c13 = new PdfPCell(new Paragraph(" "));
                    c13.MinimumHeight = 40f;
                    PdfPCell c23 = new PdfPCell(new Paragraph("VoBo DIRECTOR TÉCNICO", font10b));
                    c23.HorizontalAlignment = Element.ALIGN_CENTER;
                    tbldictamen.AddCell(c11);
                    tbldictamen.AddCell(c12);
                    tbldictamen.AddCell(c13);
                    tbldictamen.AddCell(c23);

                    //PdfPCell c31 = new PdfPCell(new Paragraph("DICTAMEN"));
                    //PdfPCell c32 = new PdfPCell(new Paragraph("ANALISTA"));
                    PdfPCell c33 = new PdfPCell(new Paragraph(" "));
                    c33.MinimumHeight = 40f;
                    c33.Rowspan = 2;
                    tbldictamen.AddCell(c33);

                    /* PdfPCell c41 = new PdfPCell(new Paragraph("FECHA: " + certificado.fecha_analisis.ToShortDateString(), font10b));
                     c41.Colspan = 3;
                     c41.HorizontalAlignment = Element.ALIGN_CENTER;
                     c41.Border = 0;
                     tbldictamen.AddCell(c41);*/

                    doc.Add(tbldictamen);
                    #endregion



                    doc.Close();
                }
            }
            // Catching iTextSharp.text.DocumentException if any
            catch (DocumentException de)
            {
                throw de;
            }
            // Catching System.IO.IOException if any
            catch (IOException ioe)
            {
                throw ioe;
            }
        }



        class HeaderFooter : PdfPageEventHelper
        {
            string tipo_certificado = "";
            public HeaderFooter(string cod)
            {
                this.tipo_certificado= cod;
            }
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font12 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font font11 = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font font10 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

                // base.OnEndPage(writer, document);
                PdfPTable tbHeader = new PdfPTable(2);
                tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbHeader.DefaultCell.Border = 0;

                float[] widths = new float[] { 1f, 10f };
                tbHeader.SetWidths(widths);
                tbHeader.DefaultCell.Border = Rectangle.NO_BORDER;

            

                Image logo_lafar = Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/lafar.png"));
                float percentage = 0.0f;
                percentage = 100 /logo_lafar.Width;
                logo_lafar.ScalePercent(percentage*100);
 
                logo_lafar.SetAbsolutePosition(document.Left, document.Top);
                document.Add(logo_lafar);

                PdfPCell c_logo = new PdfPCell(new Paragraph());
                c_logo.Rowspan = 4;
                c_logo.Border = 0;
                tbHeader.AddCell(c_logo);

                PdfPCell c_t1 = new PdfPCell(new Paragraph("LABORATORIOS FARMACÉUTICOS LAFAR S.A.", font12));
                c_t1.HorizontalAlignment = Element.ALIGN_CENTER;
                c_t1.Border = 0;
                tbHeader.AddCell(c_t1);
                
                PdfPCell c_t2 = new PdfPCell(new Paragraph("DEPARTAMENTO DE CONTROL DE CALIDAD", font11));
                c_t2.HorizontalAlignment = Element.ALIGN_CENTER;
                c_t2.Border = 0;
                tbHeader.AddCell(c_t2);
                
                PdfPCell c_t3 = new PdfPCell(new Paragraph("CERTIFICADO DE ANÁLISIS", font11));
                c_t3.HorizontalAlignment = Element.ALIGN_CENTER;
                c_t3.Border = 0;
                tbHeader.AddCell(c_t3);
                
                PdfPCell c_t4 = new PdfPCell(new Paragraph("MATERIA PRIMA - " + this.tipo_certificado, font11));
                c_t4.HorizontalAlignment = Element.ALIGN_CENTER;
                c_t4.Border = 0;
                tbHeader.AddCell(c_t4);
                

                
                tbHeader.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetTop(document.TopMargin)+70, writer.DirectContent);

                PdfPTable tbFooter = new PdfPTable(3);
                tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                tbFooter.DefaultCell.Border = 0;
                tbFooter.AddCell(new Paragraph());

                PdfPCell _cell_f = new PdfPCell();
                _cell_f = new PdfPCell(new Paragraph("Este Documento ha sido diseñado electrónicamente. Por lo tanto es válido", font10));
                _cell_f.HorizontalAlignment = Element.ALIGN_CENTER;
                _cell_f.Border = 0;

                tbFooter.AddCell(_cell_f);

               /* _cell_f = new PdfPCell(new Paragraph("Página " + writer.PageNumber));
                _cell_f.HorizontalAlignment = Element.ALIGN_RIGHT;
                _cell_f.Border = 0;

                tbFooter.AddCell(_cell_f);*/
                tbFooter.WriteSelectedRows(0, -1, document.LeftMargin, writer.PageSize.GetBottom(document.BottomMargin) + 110, writer.DirectContent);

                //tbFooter.DefaultCell.Border = 0;
            }
        }
    }
}
