using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CapaModelos;
using CapaNegocio;
using Comunes;

namespace Reportes
{
    public class OrdenCompra
    {
        // Variable para cambiar el nombre del archivo
        string nuevo_nombre_archivo = "";
        // Cabecera
        OPOR opor = new OPOR();
        OPOR2 opor2 = new OPOR2();

        // Detalle Cabecera
        POR1 por1 = new POR1();
        POR1X por1x = new POR1X();

        string rutaOrden = Parametros.rutaOrdenCompra();
        string rutaDetalleOrden = Parametros.rutaDetalleOrdenCompra();

        List<OCOrdenCompraX> lorden = new List<OCOrdenCompraX>(); // Lista de Orden de Compra
        List<OCDetalleOrdenCompra> ldetalleorden = new List<OCDetalleOrdenCompra>(); // Lista de detalle de orden 

        SCOrdenCompraNegocio ocn = new SCOrdenCompraNegocio();
        SCDetalleOrdenCompraNegocio don = new SCDetalleOrdenCompraNegocio(); 
        SCExportarOrdenCompraNegocio nocn = new SCExportarOrdenCompraNegocio();

        public void crearReporteOrdenCompra(string nombre_archivo)
        {
            Int64 numero_orden_compra = 0; // nocn.getNumeroOrden(); // Obtiene el ultimo numero de compra del sap
            try
            {
                StreamWriter sw = new StreamWriter(rutaOrden + nombre_archivo + ".txt"); // Crea el archivo para la cabecera
                StreamWriter sw_detalle = new StreamWriter(rutaDetalleOrden + nombre_archivo + ".txt"); // Crea el archivo para el detalle de la orden 
                string delimiter = "\t";
                opor = this.cargarOrden(); // carga las primera fila
                opor2 = this.cargarOrden2(); // carga la segunda fila
                
                lorden = ocn.GetListaOrdenCompraSinSubir();

                string line = opor.DocNum + "\t" + opor.DocType + "\t" + opor.HandWritten + "\t" + opor.Printed + "\t" + opor.DocDate + "\t" + opor.DocDueDate + "\t" + opor.CardCode + "\t" + opor.CardName + "\t" + opor.Address + "\t" + opor.NumAtCard + "\t" + opor.DocCurrency + "\t" + opor.DocRate + "\t" + opor.DocTotal + "\t" + opor.Reference1 + "\t" + opor.Reference2 + "\t" + opor.Comments + "\t" + opor.JournalMemo + "\t" + opor.PaymentGroupCode + "\t" + opor.DocTime + "\t" + opor.SalesPersonCode + "\t" + opor.TransportationCode + "\t" + opor.Confirmed + "\t" + opor.ImportFileNum + "\t" + opor.SummeryType + "\t" + opor.ContactPersonCode + "\t" + opor.ShowSCN + "\t" + opor.Series + "\t" + opor.TaxDate + "\t" + opor.PartialSupply + "\t" + opor.DocObjectCode + "\t" + opor.ShipToCode + "\t" + opor.Indicator + "\t" + opor.FederalTaxID + "\t" + opor.DiscountPercent + "\t" + opor.PaymentReference + "\t" + opor.DocTotalFc + "\t" + opor.Form1099 + "\t" + opor.Box1099 + "\t" + opor.RevisionPo + "\t" + opor.RequriedDate + "\t" + opor.CancelDate + "\t" + opor.BlockDunning + "\t" + opor.Pick + "\t" + opor.PaymentMethod + "\t" + opor.PaymentBlock + "\t" + opor.PaymentBlockEntry + "\t" + opor.CentralBankIndicator + "\t" + opor.MaximumCashDiscount + "\t" + opor.Project + "\t" + opor.ExemptionValidityDateFrom + "\t" + opor.ExemptionValidityDateTo + "\t" + opor.WareHouseUpdateType + "\t" + opor.Rounding + "\t" + opor.ExternalCorrectedDocNum + "\t" + opor.InternalCorrectedDocNum + "\t" + opor.DeferredTax + "\t" + opor.TaxExemptionLetterNum + "\t" + opor.AgentCode + "\t" + opor.NumberOfInstallments + "\t" + opor.ApplyTaxOnFirstInstallment + "\t" + opor.VatDate + "\t" + opor.DocumentsOwner + "\t" + opor.FolioPrefixString + "\t" + opor.FolioNumber + "\t" + opor.DocumentSubType + "\t" + opor.BPChannelCode + "\t" + opor.BPChannelContact + "\t" + opor.Address2 + "\t" + opor.PayToCode + "\t" + opor.ManualNumber + "\t" + opor.UseShpdGoodsAct + "\t" + opor.IsPayToBank + "\t" + opor.PayToBankCountry + "\t" + opor.PayToBankCode + "\t" + opor.PayToBankAccountNo + "\t" + opor.PayToBankBranch + "\t" + opor.BPL_IDAssignedToInvoice + "\t" + opor.DownPayment + "\t" + opor.ReserveInvoice + "\t" + opor.LanguageCode + "\t" + opor.TrackingNumber + "\t" + opor.PickRemark + "\t" + opor.ClosingDate + "\t" + opor.SequenceCode + "\t" + opor.SequenceSerial + "\t" + opor.SeriesString + "\t" + opor.SubSeriesString + "\t" + opor.SequenceModel + "\t" + opor.UseCorrectionVATGroup + "\t" + opor.DownPaymentAmount + "\t" + opor.DownPaymentPercentage + "\t" + opor.DownPaymentType + "\t" + opor.DownPaymentAmountSC + "\t" + opor.DownPaymentAmountFC + "\t" + opor.VatPercent + "\t" + opor.ServiceGrossProfitPercent + "\t" + opor.OpeningRemarks + "\t" + opor.ClosingRemarks + "\t" + opor.RoundingDiffAmount + "\t" + opor.ControlAccount + "\t" + opor.InsuranceOperation347 + "\t" + opor.ArchiveNonremovableSalesQuotation + "\t" + opor.u_deptocomp;
                string line2 = opor2.DocNum + "\t" + opor2.DocType + "\t" + opor2.Handwrtten + "\t" + opor2.Printed + "\t" + opor2.DocDate + "\t" + opor2.DocDueDate + "\t" + opor2.CardCode + "\t" + opor2.CardName + "\t" + opor2.Address + "\t" + opor2.NumAtCard + "\t" + opor2.DocCur + "\t" + opor2.DocRate + "\t" + opor2.DocTotal + "\t" + opor2.Ref1 + "\t" + opor2.Ref2 + "\t" + opor2.Comments + "\t" + opor2.JrnlMemo + "\t" + opor2.GroupNum + "\t" + opor2.DocTime + "\t" + opor2.SlpCode + "\t" + opor2.TrnspCode + "\t" + opor2.Confirmed + "\t" + opor2.ImportEnt + "\t" + opor2.SummryType + "\t" + opor2.CntctCode + "\t" + opor2.ShowSCN + "\t" + opor2.Series + "\t" + opor2.TaxDate + "\t" + opor2.PartSupply + "\t" + opor2.ObjType + "\t" + opor2.ShipToCode + "\t" + opor2.Indicator + "\t" + opor2.LicTradNum + "\t" + opor2.DiscPrcnt + "\t" + opor2.PaymentRef + "\t" + opor2.DocTotalFC + "\t" + opor2.Form1099 + "\t" + opor2.Box1099 + "\t" + opor2.RevisionPo + "\t" + opor2.ReqDate + "\t" + opor2.CancelDate + "\t" + opor2.BlockDunn + "\t" + opor2.Pick + "\t" + opor2.PeyMethod + "\t" + opor2.PayBlock + "\t" + opor2.PayBlckRef + "\t" + opor2.CntrlBnk + "\t" + opor2.MaxDscn + "\t" + opor2.Project + "\t" + opor2.FromDate + "\t" + opor2.ToDate + "\t" + opor2.UpdInvnt + "\t" + opor2.Rounding + "\t" + opor2.CorrExt + "\t" + opor2.CorrInv + "\t" + opor2.DeferrTax + "\t" + opor2.LetterNum + "\t" + opor2.AgentCode + "\t" + opor2.Installmnt + "\t" + opor2.VATFirst + "\t" + opor2.VatDate + "\t" + opor2.OwnerCode + "\t" + opor2.FolioPref + "\t" + opor2.FolioNum + "\t" + opor2.DocSubType + "\t" + opor2.BPChCode + "\t" + opor2.BPChCntc + "\t" + opor2.Address2 + "\t" + opor2.PayToCode + "\t" + opor2.ManualNum + "\t" + opor2.UseShpdGd + "\t" + opor2.IsPaytoBnk + "\t" + opor2.BnkCntry + "\t" + opor2.BankCode + "\t" + opor2.BnkAccount + "\t" + opor2.BnkBranch + "\t" + opor2.BPLId + "\t" + opor2.DpmPrcnt + "\t" + opor2.isIns + "\t" + opor2.LangCode + "\t" + opor2.TrackNo + "\t" + opor2.PickRmrk + "\t" + opor2.ClsDate + "\t" + opor2.SeqCode + "\t" + opor2.Serial + "\t" + opor2.SeriesStr + "\t" + opor2.SubStr + "\t" + opor2.Model + "\t" + opor2.UseCorrVat + "\t" + opor2.DpmAmnt + "\t" + opor2.DpmPrcnt + "\t" + opor2.Posted + "\t" + opor2.DpmAmntSC + "\t" + opor2.DpmAmntFC + "\t" + opor2.VatPercent + "\t" + opor2.SrvGpPrcnt + "\t" + opor2.Header + "\t" + opor2.Footer + "\t" + opor2.RoundDif + "\t" + opor2.CtlAccount + "\t" + opor2.InsurOp347 + "\t" + opor2.IgnRelDoc + "\t" + opor2.u_deptocomp;
                string lineN = "";

                // Escribir las primeras lineas
                sw.WriteLine(line);
                sw.WriteLine(line2);

                // Escribimos en el archivo detalle orden de compra
                por1 = this.cargarDetalleOrden1();
                por1x = this.cargaDetalleOrden2();

                string line_doc = por1.ParentKey + delimiter + por1.LineNum + delimiter + por1.ItemCode + delimiter + por1.ItemDescription + delimiter + por1.Quantity + delimiter + por1.ShipDate + delimiter + por1.Price + delimiter + por1.PriceAfterVAT + delimiter + por1.Currency + delimiter + por1.Rate + delimiter + por1.DiscountPercent + delimiter + por1.VendorNum + delimiter + por1.SerialNum + delimiter + por1.WarehouseCode + delimiter + por1.SalesPersonCode + delimiter + por1.CommisionPercent + delimiter + por1.TreeType + delimiter + por1.AccountCode + delimiter + por1.UseBaseUnits + delimiter + por1.SupplierCatNum + delimiter + por1.CostingCode + delimiter + por1.ProjectCode + delimiter + por1.BarCode + delimiter + por1.VatGroup + delimiter + por1.Height1 + delimiter + por1.Hight1Unit + delimiter + por1.Height2 + delimiter + por1.Height2Unit + delimiter + por1.Lengh1 + delimiter + por1.Lengh1Unit + delimiter + por1.Lengh2 + delimiter + por1.Lengh2Unit + delimiter + por1.Weight1 + delimiter + por1.Weight1Unit + delimiter + por1.Weight2 + delimiter + por1.Weight2Unit + delimiter + por1.Factor1 + delimiter + por1.Factor2 + delimiter + por1.Factor3 + delimiter + por1.Factor4 + delimiter + por1.BaseType + delimiter + por1.BaseEntry + delimiter + por1.BaseLine + delimiter + por1.Volume + delimiter + por1.VolumeUnit + delimiter + por1.Width1 + delimiter + por1.Width1Unit + delimiter + por1.Width2 + delimiter + por1.Width2Unit + delimiter + por1.Address + delimiter + por1.TaxCode + delimiter + por1.TaxType + delimiter + por1.TaxLiable + delimiter + por1.BackOrder + delimiter + por1.FreeText + delimiter + por1.ShippingMethod + delimiter + por1.CorrectionInvoiceItem + delimiter + por1.CorrInvAmountToStock + delimiter + por1.CorrInvAmountToDiffAcct + delimiter + por1.WTLiable + delimiter + por1.DeferredTax + delimiter + por1.MeasureUnit + delimiter + por1.UnitsOfMeasurment + delimiter + por1.LineTotal + delimiter + por1.TaxPercentagePerRow + delimiter + por1.TaxTotal + delimiter + por1.ConsumerSalesForecast + delimiter + por1.ExciseAmount + delimiter + por1.CountryOrg + delimiter + por1.SWW + delimiter + por1.TransactionType + delimiter + por1.DistributeExpense + delimiter + por1.ShipToCode + delimiter + por1.RowTotalFC + delimiter + por1.CFOPCode + delimiter + por1.CSTCode + delimiter + por1.Usage + delimiter + por1.TaxOnly + delimiter + por1.UnitPrice + delimiter + por1.LineStatus + delimiter + por1.LineType + delimiter + por1.COGSCostingCode + delimiter + por1.COGSAccountCode + delimiter + por1.ChangeAssemlyBoMWarehouse + delimiter + por1.GrossBuyPrice + delimiter + por1.GrossBase + delimiter + por1.GrossProfitTotalBasePrice + delimiter + por1.CostingCode2 + delimiter + por1.CostingCode3 + delimiter + por1.CostingCode4 + delimiter + por1.CostingCode5 + delimiter + por1.ItemDetails + delimiter + por1.LocationCode + delimiter + por1.ActualDeliveryDate + delimiter + por1.ExLineNo + delimiter + por1.RequiredDate + delimiter + por1.RequiredQuantity + delimiter + por1.COGSCostingCode2 + delimiter + por1.COGSCostingCode3 + delimiter + por1.COGSCostingCode4 + delimiter + por1.COGSCostingCode5 + delimiter + por1.WithoutInventoryMovement + delimiter + por1.AgrementNo + delimiter + por1.AgreementRowNumber + delimiter + por1.ShipToDescription;
                string line_doc2 = por1x.DocNum + delimiter + por1x.LineNum + delimiter + por1x.ItemCode + delimiter + por1x.Dscription + delimiter + por1x.Quantity + delimiter + por1x.ShipDate + delimiter + por1x.Price + delimiter + por1x.PriceAfVAT + delimiter + por1x.Currency + delimiter + por1x.Rate + delimiter + por1x.DiscPrcnt + delimiter + por1x.VendorNum + delimiter + por1x.SerialNum + delimiter + por1x.WhsCode + delimiter + por1x.SlpCode + delimiter + por1x.Commission + delimiter + por1x.TreeType + delimiter + por1x.AcctCode + delimiter + por1x.UseBaseUn + delimiter + por1x.SubCatNum + delimiter + por1x.OcrCode + delimiter + por1x.Project + delimiter + por1x.CodeBars + delimiter + por1x.VatGroup + delimiter + por1x.Height1 + delimiter + por1x.Hght1Unit + delimiter + por1x.Height2 + delimiter + por1x.Hght2Unit + delimiter + por1x.Length1 + delimiter + por1x.Len1Unit + delimiter + por1x.length2 + delimiter + por1x.Len2Unit + delimiter + por1x.Weight1 + delimiter + por1x.Wght1Unit + delimiter + por1x.Weight2 + delimiter + por1x.Wght2Unit + delimiter + por1x.Factor1 + delimiter + por1x.Factor2 + delimiter + por1x.Factor3 + delimiter + por1x.Factor4 + delimiter + por1x.BaseType + delimiter + por1x.BaseEntry + delimiter + por1x.BaseLine + delimiter + por1x.Volume + delimiter + por1x.VolUnit + delimiter + por1x.Width1 + delimiter + por1x.Wdth1Unit + delimiter + por1x.Width2 + delimiter + por1x.Wdth2Unit + delimiter + por1x.Address + delimiter + por1x.TaxCode + delimiter + por1x.TaxType + delimiter + por1x.TaxStatus + delimiter + por1x.BackOrdr + delimiter + por1x.FreeTxt + delimiter + por1x.TrnsCode + delimiter + por1x.CEECFlag + delimiter + por1x.ToStock + delimiter + por1x.ToDiff + delimiter + por1x.WtLiable + delimiter + por1x.DeferrTax + delimiter + por1x.unitMsr + delimiter + por1x.NumPerMsr + delimiter + por1x.LineTotal + delimiter + por1x.VatPrcnt + delimiter + por1x.VatSum + delimiter + por1x.ConsumeFCT + delimiter + por1x.ExciseAmt + delimiter + por1x.CountryOrg + delimiter + por1x.SWW + delimiter + por1x.TranType + delimiter + por1x.DistribExp + delimiter + por1x.ShipToCode + delimiter + por1x.TotalFrgn + delimiter + por1x.CFOPCode + delimiter + por1x.CSTCode + delimiter + por1x.Usage + delimiter + por1x.TaxOnly + delimiter + por1x.PriceBefDi + delimiter + por1x.LineStatus + delimiter + por1x.LineType + delimiter + por1x.CogsOcrCod + delimiter + por1x.CogsAcct + delimiter + por1x.ChgAsmBoMW + delimiter + por1x.GrossBuyPr + delimiter + por1x.GrossBase + delimiter + por1x.GPTtlBasPr + delimiter + por1x.OcrCode2 + delimiter + por1x.OcrCode3 + delimiter + por1x.OcrCode4 + delimiter + por1x.OcrCode5 + delimiter + por1x.Text + delimiter + por1x.LocCode + delimiter + por1x.ActDelDate + delimiter + por1x.ExLineNo + delimiter + por1x.PQTReqDate + delimiter + por1x.PQTReqQty + delimiter + por1x.CogsOcrCo2 + delimiter + por1x.CogsOcrCo3 + delimiter + por1x.CogsOcrCo4 + delimiter + por1x.CogsOcrCo5 + delimiter + por1x.NoInvtryMv + delimiter + por1x.AgrNo + delimiter + por1x.AgrLnNum + delimiter + por1x.ShipToDesc;

                sw_detalle.WriteLine(line_doc);
                sw_detalle.WriteLine(line_doc2);

                // Leer y escribir las ordenes de compra
                foreach (OCOrdenCompraX item in lorden)
                {
                    #region ORDEN DE COMPRA
                    numero_orden_compra++;
                    lineN = "";
                    OPOR2 o = new OPOR2();

                    DateTime fecha_orden = DateTime.Parse(item.fecha_orden);

                    o.DocNum = numero_orden_compra.ToString();
                    o.DocType = item.tipo_orden;
                    o.Handwrtten = " ";
                    o.Printed = " ";
                    o.DocDate = fecha_orden.ToString("yyyyMMdd");
                    o.DocDueDate = " ";
                    o.CardCode = item.codigo_proveedor;
                    o.CardName = " ";
                    o.Address = " ";
                    o.NumAtCard = " ";
                    o.DocCur = " ";
                    o.DocRate = " ";
                    o.DocTotal = " ";
                    o.Ref1 = " ";
                    o.Ref2 = " ";
                    o.Comments = item.motivo_orden;
                    o.JrnlMemo = " ";
                    o.GroupNum = " ";
                    o.DocTime = " ";
                    o.SlpCode = " ";
                    o.TrnspCode = " ";
                    o.Confirmed = " ";
                    o.ImportEnt = " ";
                    o.SummryType = " ";
                    o.CntctCode = " ";
                    o.ShowSCN = " ";
                    o.Series = " ";
                    o.TaxDate = " ";
                    o.PartSupply = " ";
                    o.ObjType = " ";
                    o.ShipToCode = " ";
                    o.Indicator = " ";
                    o.LicTradNum = " ";
                    o.DiscPrcnt = " ";
                    o.PaymentRef = " ";
                    o.DocTotalFC = " ";
                    o.Form1099 = " ";
                    o.Box1099 = " ";
                    o.RevisionPo = " ";
                    o.ReqDate = " ";
                    o.CancelDate = " ";
                    o.BlockDunn = " ";
                    o.Pick = " ";
                    o.PeyMethod = " ";
                    o.PayBlock = " ";
                    o.PayBlckRef = " ";
                    o.CntrlBnk = " ";
                    o.MaxDscn = " ";
                    o.Project = " ";
                    o.FromDate = " ";
                    o.ToDate = " ";
                    o.UpdInvnt = " ";
                    o.Rounding = " ";
                    o.CorrExt = " ";
                    o.CorrInv = " ";
                    o.DeferrTax = " ";
                    o.LetterNum = " ";
                    o.AgentCode = " ";
                    o.Installmnt = " ";
                    o.VATFirst = " ";
                    o.VatDate = " ";
                    o.OwnerCode = " ";
                    o.FolioPref = " ";
                    o.FolioNum = " ";
                    o.DocSubType = " ";
                    o.BPChCode = " ";
                    o.BPChCntc = " ";
                    o.Address2 = " ";
                    o.PayToCode = " ";
                    o.ManualNum = " ";
                    o.UseShpdGd = " ";
                    o.IsPaytoBnk = " ";
                    o.BnkCntry = " ";
                    o.BankCode = " ";
                    o.BnkAccount = " ";
                    o.BnkBranch = " ";
                    o.BPLId = " ";
                    o.DpmPrcnt = " ";
                    o.isIns = " ";
                    o.LangCode = " ";
                    o.TrackNo = " ";
                    o.PickRmrk = " ";
                    o.ClsDate = " ";
                    o.SeqCode = " ";
                    o.Serial = " ";
                    o.SeriesStr = " ";
                    o.SubStr = " ";
                    o.Model = " ";
                    o.UseCorrVat = " ";
                    o.DpmAmnt = " ";
                    o.DpmPrcnt = " ";
                    o.Posted = " ";
                    o.DpmAmntSC = " ";
                    o.DpmAmntFC = " ";
                    o.VatPercent = " ";
                    o.SrvGpPrcnt = " ";
                    o.Header = " ";
                    o.Footer = " ";
                    o.RoundDif = " ";
                    o.CtlAccount = " ";
                    o.InsurOp347 = " ";
                    o.IgnRelDoc = " ";
                    o.u_deptocomp = item.tipo_compra;

                    lineN = o.DocNum + "\t" + o.DocType + "\t" + o.Handwrtten + "\t" + o.Printed + "\t" + o.DocDate + "\t" + o.DocDueDate + "\t" + o.CardCode + "\t" + o.CardName + "\t" + o.Address + "\t" + o.NumAtCard + "\t" + o.DocCur + "\t" + o.DocRate + "\t" + o.DocTotal + "\t" + o.Ref1 + "\t" + o.Ref2 + "\t" + o.Comments + "\t" + o.JrnlMemo + "\t" + o.GroupNum + "\t" + o.DocTime + "\t" + o.SlpCode + "\t" + o.TrnspCode + "\t" + o.Confirmed + "\t" + o.ImportEnt + "\t" + o.SummryType + "\t" + o.CntctCode + "\t" + o.ShowSCN + "\t" + o.Series + "\t" + o.TaxDate + "\t" + o.PartSupply + "\t" + o.ObjType + "\t" + o.ShipToCode + "\t" + o.Indicator + "\t" + o.LicTradNum + "\t" + o.DiscPrcnt + "\t" + o.PaymentRef + "\t" + o.DocTotalFC + "\t" + o.Form1099 + "\t" + o.Box1099 + "\t" + o.RevisionPo + "\t" + o.ReqDate + "\t" + o.CancelDate + "\t" + o.BlockDunn + "\t" + o.Pick + "\t" + o.PeyMethod + "\t" + o.PayBlock + "\t" + o.PayBlckRef + "\t" + o.CntrlBnk + "\t" + o.MaxDscn + "\t" + o.Project + "\t" + o.FromDate + "\t" + o.ToDate + "\t" + o.UpdInvnt + "\t" + o.Rounding + "\t" + o.CorrExt + "\t" + o.CorrInv + "\t" + o.DeferrTax + "\t" + o.LetterNum + "\t" + o.AgentCode + "\t" + o.Installmnt + "\t" + o.VATFirst + "\t" + o.VatDate + "\t" + o.OwnerCode + "\t" + o.FolioPref + "\t" + o.FolioNum + "\t" + o.DocSubType + "\t" + o.BPChCode + "\t" + o.BPChCntc + "\t" + o.Address2 + "\t" + o.PayToCode + "\t" + o.ManualNum + "\t" + o.UseShpdGd + "\t" + o.IsPaytoBnk + "\t" + o.BnkCntry + "\t" + o.BankCode + "\t" + o.BnkAccount + "\t" + o.BnkBranch + "\t" + o.BPLId + "\t" + o.DpmPrcnt + "\t" + o.isIns + "\t" + o.LangCode + "\t" + o.TrackNo + "\t" + o.PickRmrk + "\t" + o.ClsDate + "\t" + o.SeqCode + "\t" + o.Serial + "\t" + o.SeriesStr + "\t" + o.SubStr + "\t" + o.Model + "\t" + o.UseCorrVat + "\t" + o.DpmAmnt + "\t" + o.DpmPrcnt + "\t" + o.Posted + "\t" + o.DpmAmntSC + "\t" + o.DpmAmntFC + "\t" + o.VatPercent + "\t" + o.SrvGpPrcnt + "\t" + o.Header + "\t" + o.Footer + "\t" + o.RoundDif + "\t" + o.CtlAccount + "\t" + o.InsurOp347 + "\t" + o.IgnRelDoc + "\t" + o.u_deptocomp;
                    sw.WriteLine(lineN);

                    RequestUpdateEstadoSubidaOrden r = new RequestUpdateEstadoSubidaOrden();
                    r.numero_orden_compra = numero_orden_compra;
                    r.estado_transferencia = "Y";
                    r.codigo_orden = item.codigo_orden;
                    new SCExportarOrdenCompraNegocio().updateEstadoSubidaOrden(r);
                    #endregion

                    // Lista de Detalle de Orden por Codigo de Orden
                    List<OCDetalleOrdenCompra> ldo = new List<OCDetalleOrdenCompra>();
                    ldo = don.GetDetalleOrdenCompra(item.codigo_orden); // obtenemos detalle por codigo de orden
                    POR1 p = new POR1();
                    
                    //Numero de Linea para el Item de la Orden de Compra
                    int numero_linea = 0;

                    #region CARGAR DETALLE ORDEN DE COMPRA
                    foreach (var itemdoc in ldo)
                    {
                        p = new POR1();
                        string linedoN = "";
                        p.ParentKey = numero_orden_compra.ToString();
                        p.LineNum = numero_linea.ToString();
                        p.ItemCode = itemdoc.codigo_item;
                        p.ItemDescription = " ";
                        p.Quantity = itemdoc.cantidad.ToString();
                        p.ShipDate = " ";
                        p.Price = " ";
                        p.PriceAfterVAT = itemdoc.precio_unitario.ToString();
                        p.Currency = " ";
                        p.Rate = " ";
                        p.DiscountPercent = " ";
                        p.VendorNum = " ";
                        p.SerialNum = " ";
                        p.WarehouseCode = " ";
                        p.SalesPersonCode = " ";
                        p.CommisionPercent = " ";
                        p.TreeType = " ";
                        p.AccountCode = " ";
                        p.UseBaseUnits = " ";
                        p.SupplierCatNum = " ";
                        p.CostingCode = " ";
                        p.ProjectCode = " ";
                        p.BarCode = " ";
                        p.VatGroup = " ";
                        p.Height1 = " ";
                        p.Hight1Unit = " ";
                        p.Height2 = " ";
                        p.Height2Unit = " ";
                        p.Lengh1 = " ";
                        p.Lengh1Unit = " ";
                        p.Lengh2 = " ";
                        p.Lengh2Unit = " ";
                        p.Weight1 = " ";
                        p.Weight1Unit = " ";
                        p.Weight2 = " ";
                        p.Weight2Unit = " ";
                        p.Factor1 = " ";
                        p.Factor2 = " ";
                        p.Factor3 = " ";
                        p.Factor4 = " ";
                        p.BaseType = " ";
                        p.BaseEntry = " ";
                        p.BaseLine = " ";
                        p.Volume = " ";
                        p.VolumeUnit = " ";
                        p.Width1 = " ";
                        p.Width1Unit = " ";
                        p.Width2 = " ";
                        p.Width2Unit = " ";
                        p.Address = " ";
                        p.TaxCode = " ";
                        p.TaxType = " ";
                        p.TaxLiable = " ";
                        p.BackOrder = " ";
                        p.FreeText = " ";
                        p.ShippingMethod = " ";
                        p.CorrectionInvoiceItem = " ";
                        p.CorrInvAmountToStock = " ";
                        p.CorrInvAmountToDiffAcct = " ";
                        p.WTLiable = " ";
                        p.DeferredTax = " ";
                        p.MeasureUnit = " ";
                        p.UnitsOfMeasurment = " ";
                        p.LineTotal = " ";
                        p.TaxPercentagePerRow = " ";
                        p.TaxTotal = " ";
                        p.ConsumerSalesForecast = " ";
                        p.ExciseAmount = " ";
                        p.CountryOrg = " ";
                        p.SWW = " ";
                        p.TransactionType = " ";
                        p.DistributeExpense = " ";
                        p.ShipToCode = " ";
                        p.RowTotalFC = " ";
                        p.CFOPCode = " ";
                        p.CSTCode = " ";
                        p.Usage = " ";
                        p.TaxOnly = " ";
                        p.UnitPrice = " ";
                        p.LineStatus = " ";
                        p.LineType = " ";
                        p.COGSCostingCode = " ";
                        p.COGSAccountCode = " ";
                        p.ChangeAssemlyBoMWarehouse = " ";
                        p.GrossBuyPrice = " ";
                        p.GrossBase = " ";
                        p.GrossProfitTotalBasePrice = " ";
                        p.CostingCode2 = " ";
                        p.CostingCode3 = " ";
                        p.CostingCode4 = " ";
                        p.CostingCode5 = " ";
                        p.ItemDetails = " ";
                        p.LocationCode = " ";
                        p.ActualDeliveryDate = " ";
                        p.ExLineNo = " ";
                        p.RequiredDate = " ";
                        p.RequiredQuantity = " ";
                        p.COGSCostingCode2 = " ";
                        p.COGSCostingCode3 = " ";
                        p.COGSCostingCode4 = " ";
                        p.COGSCostingCode5 = " ";
                        p.WithoutInventoryMovement = " ";
                        p.AgrementNo = " ";
                        p.AgreementRowNumber = " ";
                        p.ShipToDescription = " ";

                        linedoN = p.ParentKey + delimiter + p.LineNum + delimiter + p.ItemCode + delimiter + p.ItemDescription + delimiter + p.Quantity + delimiter + p.ShipDate + delimiter + p.Price + delimiter + p.PriceAfterVAT + delimiter + p.Currency + delimiter + p.Rate + delimiter + p.DiscountPercent + delimiter + p.VendorNum + delimiter + p.SerialNum + delimiter + p.WarehouseCode + delimiter + p.SalesPersonCode + delimiter + p.CommisionPercent + delimiter + p.TreeType + delimiter + p.AccountCode + delimiter + p.UseBaseUnits + delimiter + p.SupplierCatNum + delimiter + p.CostingCode + delimiter + p.ProjectCode + delimiter + p.BarCode + delimiter + p.VatGroup + delimiter + p.Height1 + delimiter + p.Hight1Unit + delimiter + p.Height2 + delimiter + p.Height2Unit + delimiter + p.Lengh1 + delimiter + p.Lengh1Unit + delimiter + p.Lengh2 + delimiter + p.Lengh2Unit + delimiter + p.Weight1 + delimiter + p.Weight1Unit + delimiter + p.Weight2 + delimiter + p.Weight2Unit + delimiter + p.Factor1 + delimiter + p.Factor2 + delimiter + p.Factor3 + delimiter + p.Factor4 + delimiter + p.BaseType + delimiter + p.BaseEntry + delimiter + p.BaseLine + delimiter + p.Volume + delimiter + p.VolumeUnit + delimiter + p.Width1 + delimiter + p.Width1Unit + delimiter + p.Width2 + delimiter + p.Width2Unit + delimiter + p.Address + delimiter + p.TaxCode + delimiter + p.TaxType + delimiter + p.TaxLiable + delimiter + p.BackOrder + delimiter + p.FreeText + delimiter + p.ShippingMethod + delimiter + p.CorrectionInvoiceItem + delimiter + p.CorrInvAmountToStock + delimiter + p.CorrInvAmountToDiffAcct + delimiter + p.WTLiable + delimiter + p.DeferredTax + delimiter + p.MeasureUnit + delimiter + p.UnitsOfMeasurment + delimiter + p.LineTotal + delimiter + p.TaxPercentagePerRow + delimiter + p.TaxTotal + delimiter + p.ConsumerSalesForecast + delimiter + p.ExciseAmount + delimiter + p.CountryOrg + delimiter + p.SWW + delimiter + p.TransactionType + delimiter + p.DistributeExpense + delimiter + p.ShipToCode + delimiter + p.RowTotalFC + delimiter + p.CFOPCode + delimiter + p.CSTCode + delimiter + p.Usage + delimiter + p.TaxOnly + delimiter + p.UnitPrice + delimiter + p.LineStatus + delimiter + p.LineType + delimiter + p.COGSCostingCode + delimiter + p.COGSAccountCode + delimiter + p.ChangeAssemlyBoMWarehouse + delimiter + p.GrossBuyPrice + delimiter + p.GrossBase + delimiter + p.GrossProfitTotalBasePrice + delimiter + p.CostingCode2 + delimiter + p.CostingCode3 + delimiter + p.CostingCode4 + delimiter + p.CostingCode5 + delimiter + p.ItemDetails + delimiter + p.LocationCode + delimiter + p.ActualDeliveryDate + delimiter + p.ExLineNo + delimiter + p.RequiredDate + delimiter + p.RequiredQuantity + delimiter + p.COGSCostingCode2 + delimiter + p.COGSCostingCode3 + delimiter + p.COGSCostingCode4 + delimiter + p.COGSCostingCode5 + delimiter + p.WithoutInventoryMovement + delimiter + p.AgrementNo + delimiter + p.AgreementRowNumber + delimiter + p.ShipToDescription;
                        sw_detalle.WriteLine(linedoN);

                        numero_linea++;
                    }
                    #endregion
                    
                }
                sw_detalle.Close();
                sw.Close();

                string aux_first = lorden.First().codigo_orden; // Obtenemos el codigo de la primera orden
                string aux_last = lorden.Last().codigo_orden; // Obtenemos el codigo de la ultima orden
                nuevo_nombre_archivo = aux_first + "_" + aux_last;
                if (File.Exists(rutaOrden + nombre_archivo + ".txt"))
	            {
		            if (!File.Exists(rutaOrden + nuevo_nombre_archivo + ".txt"))
	                {
                        File.Copy(rutaOrden + nombre_archivo + ".txt", rutaOrden + nuevo_nombre_archivo + ".txt");
                        File.Delete(rutaOrden + nombre_archivo + ".txt");
	                }
	            }

                if (File.Exists(rutaDetalleOrden + nombre_archivo + ".txt"))
                {
                    if (!File.Exists(rutaDetalleOrden + nuevo_nombre_archivo + ".txt"))
                    {
                        File.Copy(rutaDetalleOrden + nombre_archivo + ".txt", rutaDetalleOrden + nuevo_nombre_archivo + ".txt");
                        File.Delete(rutaDetalleOrden + nombre_archivo + ".txt");
                    }
                }

            }
            catch (IOException ioe)
            {
                Console.WriteLine("Excepcion: " + ioe.Message);
            }
            finally
            {
                Console.WriteLine("Se acabo la generación del archivo");
            }
        }

        public OPOR2 cargarOrden2()
        {
            return new OPOR2
            {
                DocNum = "DocNum",
                DocType = "DocType",
                Handwrtten = "Handwrtten",
                Printed = "Printed",
                DocDate = "DocDate",
                DocDueDate = "DocDueDate",
                CardCode = "CardCode",
                CardName = "CardName",
                Address = "Address",
                NumAtCard = "NumAtCard",
                DocCur = "DocCur",
                DocRate = "DocRate",
                DocTotal = "DocTotal",
                Ref1 = "Ref1",
                Ref2 = "Ref2",
                Comments = "Comments",
                JrnlMemo = "JrnlMemo",
                GroupNum = "GroupNum",
                DocTime = "DocTime",
                SlpCode = "SlpCode",
                TrnspCode = "TrnspCode",
                Confirmed = "Confirmed",
                ImportEnt = "ImportEnt",
                SummryType = "SummryType",
                CntctCode = "CntctCode",
                ShowSCN = "ShowSCN",
                Series = "Series",
                TaxDate = "TaxDate",
                PartSupply = "PartSupply",
                ObjType = "ObjType",
                ShipToCode = "ShipToCode",
                Indicator = "Indicator",
                LicTradNum = "LicTradNum",
                DiscPrcnt = "DiscPrcnt",
                PaymentRef = "PaymentRef",
                DocTotalFC = "DocTotalFC",
                Form1099 = "Form1099",
                Box1099 = "Box1099",
                RevisionPo = "RevisionPo",
                ReqDate = "ReqDate",
                CancelDate = "CancelDate",
                BlockDunn = "BlockDunn",
                Pick = "Pick",
                PeyMethod = "PeyMethod",
                PayBlock = "PayBlock",
                PayBlckRef = "PayBlckRef",
                CntrlBnk = "CntrlBnk",
                MaxDscn = "MaxDscn",
                Project = "Project",
                FromDate = "FromDate",
                ToDate = "ToDate",
                UpdInvnt = "UpdInvnt",
                Rounding = "Rounding",
                CorrExt = "CorrExt",
                CorrInv = "CorrInv",
                DeferrTax = "DeferrTax",
                LetterNum = "LetterNum",
                AgentCode = "AgentCode",
                Installmnt = "Installmnt",
                VATFirst = "VATFirst",
                VatDate = "VatDate",
                OwnerCode = "OwnerCode",
                FolioPref = "FolioPref",
                FolioNum = "FolioNum",
                DocSubType = "DocSubType",
                BPChCode = "BPChCode",
                BPChCntc = "BPChCntc",
                Address2 = "Address2",
                PayToCode = "PayToCode",
                ManualNum = "ManualNum",
                UseShpdGd = "UseShpdGd",
                IsPaytoBnk = "IsPaytoBnk",
                BnkCntry = "BnkCntry",
                BankCode = "BankCode",
                BnkAccount = "BnkAccount",
                BnkBranch = "BnkBranch",
                BPLId = "BPLId",
                DpmPrcnt = "DpmPrcnt",
                isIns = "isIns",
                LangCode = "LangCode",
                TrackNo = "TrackNo",
                PickRmrk = "PickRmrk",
                ClsDate = "ClsDate",
                SeqCode = "SeqCode",
                Serial = "Serial",
                SeriesStr = "SeriesStr",
                SubStr = "SubStr",
                Model = "Model",
                UseCorrVat = "UseCorrVat",
                DpmAmnt = "DpmAmnt",
                DpmPrcntX = "DpmPrcnt",
                Posted = "Posted",
                DpmAmntSC = "DpmAmntSC",
                DpmAmntFC = "DpmAmntFC",
                VatPercent = "VatPercent",
                SrvGpPrcnt = "SrvGpPrcnt",
                Header = "Header",
                Footer = "Footer",
                RoundDif = "RoundDif",
                CtlAccount = "CtlAccount",
                InsurOp347 = "InsurOp347",
                IgnRelDoc = "IgnRelDoc",
                u_deptocomp = "u_deptocomp",
            };
        }

        public OPOR cargarOrden()
        {
            return new OPOR
            {
                DocNum = "DocNum",
                DocType = "DocType",
                HandWritten = "HandWritten",
                Printed = "Printed",
                DocDate = "DocDate",
                DocDueDate = "DocDueDate",
                CardCode = "CardCode",
                CardName = "CardName",
                Address = "Address",
                NumAtCard = "NumAtCard",
                DocCurrency = "DocCurrency",
                DocRate = "DocRate",
                DocTotal = "DocTotal",
                Reference1 = "Reference1",
                Reference2 = "Reference2",
                Comments = "Comments",
                JournalMemo = "JournalMemo",
                PaymentGroupCode = "PaymentGroupCode",
                DocTime = "DocTime",
                SalesPersonCode = "SalesPersonCode",
                TransportationCode = "TransportationCode",
                Confirmed = "Confirmed",
                ImportFileNum = "ImportFileNum",
                SummeryType = "SummeryType",
                ContactPersonCode = "ContactPersonCode",
                ShowSCN = "ShowSCN",
                Series = "Series",
                TaxDate = "TaxDate",
                PartialSupply = "PartialSupply",
                DocObjectCode = "DocObjectCode",
                ShipToCode = "ShipToCode",
                Indicator = "Indicator",
                FederalTaxID = "FederalTaxID",
                DiscountPercent = "DiscountPercent",
                PaymentReference = "PaymentReference",
                DocTotalFc = "DocTotalFc",
                Form1099 = "Form1099",
                Box1099 = "Box1099",
                RevisionPo = "RevisionPo",
                RequriedDate = "RequriedDate",
                CancelDate = "CancelDate",
                BlockDunning = "BlockDunning",
                Pick = "Pick",
                PaymentMethod = "PaymentMethod",
                PaymentBlock = "PaymentBlock",
                PaymentBlockEntry = "PaymentBlockEntry",
                CentralBankIndicator = "CentralBankIndicator",
                MaximumCashDiscount = "MaximumCashDiscount",
                Project = "Project",
                ExemptionValidityDateFrom = "ExemptionValidityDateFrom",
                ExemptionValidityDateTo = "ExemptionValidityDateTo",
                WareHouseUpdateType = "WareHouseUpdateType",
                Rounding = "Rounding",
                ExternalCorrectedDocNum = "ExternalCorrectedDocNum",
                InternalCorrectedDocNum = "InternalCorrectedDocNum",
                DeferredTax = "DeferredTax",
                TaxExemptionLetterNum = "TaxExemptionLetterNum",
                AgentCode = "AgentCode",
                NumberOfInstallments = "NumberOfInstallments",
                ApplyTaxOnFirstInstallment = "ApplyTaxOnFirstInstallment",
                VatDate = "VatDate",
                DocumentsOwner = "DocumentsOwner",
                FolioPrefixString = "FolioPrefixString",
                FolioNumber = "FolioNumber",
                DocumentSubType = "DocumentSubType",
                BPChannelCode = "BPChannelCode",
                BPChannelContact = "BPChannelContact",
                Address2 = "Address2",
                PayToCode = "PayToCode",
                ManualNumber = "ManualNumber",
                UseShpdGoodsAct = "UseShpdGoodsAct",
                IsPayToBank = "IsPayToBank",
                PayToBankCountry = "PayToBankCountry",
                PayToBankCode = "PayToBankCode",
                PayToBankAccountNo = "PayToBankAccountNo",
                PayToBankBranch = "PayToBankBranch",
                BPL_IDAssignedToInvoice = "BPL_IDAssignedToInvoice",
                DownPayment = "DownPayment",
                ReserveInvoice = "ReserveInvoice",
                LanguageCode = "LanguageCode",
                TrackingNumber = "TrackingNumber",
                PickRemark = "PickRemark",
                ClosingDate = "ClosingDate",
                SequenceCode = "SequenceCode",
                SequenceSerial = "SequenceSerial",
                SeriesString = "SeriesString",
                SubSeriesString = "SubSeriesString",
                SequenceModel = "SequenceModel",
                UseCorrectionVATGroup = "UseCorrectionVATGroup",
                DownPaymentAmount = "DownPaymentAmount",
                DownPaymentPercentage = "DownPaymentPercentage",
                DownPaymentType = "DownPaymentType",
                DownPaymentAmountSC = "DownPaymentAmountSC",
                DownPaymentAmountFC = "DownPaymentAmountFC",
                VatPercent = "VatPercent",
                ServiceGrossProfitPercent = "ServiceGrossProfitPercent",
                OpeningRemarks = "OpeningRemarks",
                ClosingRemarks = "ClosingRemarks",
                RoundingDiffAmount = "RoundingDiffAmount",
                ControlAccount = "ControlAccount",
                InsuranceOperation347 = "InsuranceOperation347",
                ArchiveNonremovableSalesQuotation = "ArchiveNonremovableSalesQuotation",
                u_deptocomp = "u_deptocomp"
            };
        }

        public POR1 cargarDetalleOrden1()
        {
            return new POR1
            {
                ParentKey = "ParentKey",
                LineNum = "LineNum",
                ItemCode = "ItemCode",
                ItemDescription = "ItemDescription",
                Quantity = "Quantity",
                ShipDate = "ShipDate",
                Price = "Price",
                PriceAfterVAT = "PriceAfterVAT",
                Currency = "Currency",
                Rate = "Rate",
                DiscountPercent = "DiscountPercent",
                VendorNum = "VendorNum",
                SerialNum = "SerialNum",
                WarehouseCode = "WarehouseCode",
                SalesPersonCode = "SalesPersonCode",
                CommisionPercent = "CommisionPercent",
                TreeType = "TreeType",
                AccountCode = "AccountCode",
                UseBaseUnits = "UseBaseUnits",
                SupplierCatNum = "SupplierCatNum",
                CostingCode = "CostingCode",
                ProjectCode = "ProjectCode",
                BarCode = "BarCode",
                VatGroup = "VatGroup",
                Height1 = "Height1",
                Hight1Unit = "Hight1Unit",
                Height2 = "Height2",
                Height2Unit = "Height2Unit",
                Lengh1 = "Lengh1",
                Lengh1Unit = "Lengh1Unit",
                Lengh2 = "Lengh2",
                Lengh2Unit = "Lengh2Unit",
                Weight1 = "Weight1",
                Weight1Unit = "Weight1Unit",
                Weight2 = "Weight2",
                Weight2Unit = "Weight2Unit",
                Factor1 = "Factor1",
                Factor2 = "Factor2",
                Factor3 = "Factor3",
                Factor4 = "Factor4",
                BaseType = "BaseType",
                BaseEntry = "BaseEntry",
                BaseLine = "BaseLine",
                Volume = "Volume",
                VolumeUnit = "VolumeUnit",
                Width1 = "Width1",
                Width1Unit = "Width1Unit",
                Width2 = "Width2",
                Width2Unit = "Width2Unit",
                Address = "Address",
                TaxCode = "TaxCode",
                TaxType = "TaxType",
                TaxLiable = "TaxLiable",
                BackOrder = "BackOrder",
                FreeText = "FreeText",
                ShippingMethod = "ShippingMethod",
                CorrectionInvoiceItem = "CorrectionInvoiceItem",
                CorrInvAmountToStock = "CorrInvAmountToStock",
                CorrInvAmountToDiffAcct = "CorrInvAmountToDiffAcct",
                WTLiable = "WTLiable",
                DeferredTax = "DeferredTax",
                MeasureUnit = "MeasureUnit",
                UnitsOfMeasurment = "UnitsOfMeasurment",
                LineTotal = "LineTotal",
                TaxPercentagePerRow = "TaxPercentagePerRow",
                TaxTotal = "TaxTotal",
                ConsumerSalesForecast = "ConsumerSalesForecast",
                ExciseAmount = "ExciseAmount",
                CountryOrg = "CountryOrg",
                SWW = "SWW",
                TransactionType = "TransactionType",
                DistributeExpense = "DistributeExpense",
                ShipToCode = "ShipToCode",
                RowTotalFC = "RowTotalFC",
                CFOPCode = "CFOPCode",
                CSTCode = "CSTCode",
                Usage = "Usage",
                TaxOnly = "TaxOnly",
                UnitPrice = "UnitPrice",
                LineStatus = "LineStatus",
                LineType = "LineType",
                COGSCostingCode = "COGSCostingCode",
                COGSAccountCode = "COGSAccountCode",
                ChangeAssemlyBoMWarehouse = "ChangeAssemlyBoMWarehouse",
                GrossBuyPrice = "GrossBuyPrice",
                GrossBase = "GrossBase",
                GrossProfitTotalBasePrice = "GrossProfitTotalBasePrice",
                CostingCode2 = "CostingCode2",
                CostingCode3 = "CostingCode3",
                CostingCode4 = "CostingCode4",
                CostingCode5 = "CostingCode5",
                ItemDetails = "ItemDetails",
                LocationCode = "LocationCode",
                ActualDeliveryDate = "ActualDeliveryDate",
                ExLineNo = "ExLineNo",
                RequiredDate = "RequiredDate",
                RequiredQuantity = "RequiredQuantity",
                COGSCostingCode2 = "COGSCostingCode2",
                COGSCostingCode3 = "COGSCostingCode3",
                COGSCostingCode4 = "COGSCostingCode4",
                COGSCostingCode5 = "COGSCostingCode5",
                WithoutInventoryMovement = "WithoutInventoryMovement",
                AgrementNo = "AgrementNo",
                AgreementRowNumber = "AgreementRowNumber",
                ShipToDescription = "ShipToDescription"
            };
        }

        public POR1X cargaDetalleOrden2()
        {
            return new POR1X
            {
                DocNum = "DocNum",
                LineNum = "LineNum",
                ItemCode = "ItemCode",
                Dscription = "Dscription",
                Quantity = "Quantity",
                ShipDate = "ShipDate",
                Price = "Price",
                PriceAfVAT = "PriceAfVAT",
                Currency = "Currency",
                Rate = "Rate",
                DiscPrcnt = "DiscPrcnt",
                VendorNum = "VendorNum",
                SerialNum = "SerialNum",
                WhsCode = "WhsCode",
                SlpCode = "SlpCode",
                Commission = "Commission",
                TreeType = "TreeType",
                AcctCode = "AcctCode",
                UseBaseUn = "UseBaseUn",
                SubCatNum = "SubCatNum",
                OcrCode = "OcrCode",
                Project = "Project",
                CodeBars = "CodeBars",
                VatGroup = "VatGroup",
                Height1 = "Height1",
                Hght1Unit = "Hght1Unit",
                Height2 = "Height2",
                Hght2Unit = "Hght2Unit",
                Length1 = "Length1",
                Len1Unit = "Len1Unit",
                length2 = "length2",
                Len2Unit = "Len2Unit",
                Weight1 = "Weight1",
                Wght1Unit = "Wght1Unit",
                Weight2 = "Weight2",
                Wght2Unit = "Wght2Unit",
                Factor1 = "Factor1",
                Factor2 = "Factor2",
                Factor3 = "Factor3",
                Factor4 = "Factor4",
                BaseType = "BaseType",
                BaseEntry = "BaseEntry",
                BaseLine = "BaseLine",
                Volume = "Volume",
                VolUnit = "VolUnit",
                Width1 = "Width1",
                Wdth1Unit = "Wdth1Unit",
                Width2 = "Width2",
                Wdth2Unit = "Wdth2Unit",
                Address = "Address",
                TaxCode = "TaxCode",
                TaxType = "TaxType",
                TaxStatus = "TaxStatus",
                BackOrdr = "BackOrdr",
                FreeTxt = "FreeTxt",
                TrnsCode = "TrnsCode",
                CEECFlag = "CEECFlag",
                ToStock = "ToStock",
                ToDiff = "ToDiff",
                WtLiable = "WtLiable",
                DeferrTax = "DeferrTax",
                unitMsr = "unitMsr",
                NumPerMsr = "NumPerMsr",
                LineTotal = "LineTotal",
                VatPrcnt = "VatPrcnt",
                VatSum = "VatSum",
                ConsumeFCT = "ConsumeFCT",
                ExciseAmt = "ExciseAmt",
                CountryOrg = "CountryOrg",
                SWW = "SWW",
                TranType = "TranType",
                DistribExp = "DistribExp",
                ShipToCode = "ShipToCode",
                TotalFrgn = "TotalFrgn",
                CFOPCode = "CFOPCode",
                CSTCode = "CSTCode",
                Usage = "Usage",
                TaxOnly = "TaxOnly",
                PriceBefDi = "PriceBefDi",
                LineStatus = "LineStatus",
                LineType = "LineType",
                CogsOcrCod = "CogsOcrCod",
                CogsAcct = "CogsAcct",
                ChgAsmBoMW = "ChgAsmBoMW",
                GrossBuyPr = "GrossBuyPr",
                GrossBase = "GrossBase",
                GPTtlBasPr = "GPTtlBasPr",
                OcrCode2 = "OcrCode2",
                OcrCode3 = "OcrCode3",
                OcrCode4 = "OcrCode4",
                OcrCode5 = "OcrCode5",
                Text = "Text",
                LocCode = "LocCode",
                ActDelDate = "ActDelDate",
                ExLineNo = "ExLineNo",
                PQTReqDate = "PQTReqDate",
                PQTReqQty = "PQTReqQty",
                CogsOcrCo2 = "CogsOcrCo2",
                CogsOcrCo3 = "CogsOcrCo3",
                CogsOcrCo4 = "CogsOcrCo4",
                CogsOcrCo5 = "CogsOcrCo5",
                NoInvtryMv = "NoInvtryMv",
                AgrNo = "AgrNo",
                AgrLnNum = "AgrLnNum",
                ShipToDesc = "ShipToDesc"
            };
        }
    }
}
