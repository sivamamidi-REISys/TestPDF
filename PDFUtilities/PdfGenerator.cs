
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PDFUtilities_Legacy
{
    public class PdfGenerator
    {
        public void GeneratePDF(InvoiceEntity entity)
        {
            var Items = entity.Items;
            StringBuilder sb = new StringBuilder();
            //sb.Append("<p>&nbsp;</p>");
            sb.Append("<table width='100%' cellpadding='0'>");
            sb.Append("<tr><td><table width='100%' cellpadding='-3'><tr><td align='left'><b><p style='font-weight:10;font-size:11px'>Test</p></b></td></tr><tr><td align='left'><p style='color:gray;;font-size:11px'>India</p></td></tr></table></td>");
            sb.Append("<td><table width='100%' cellpadding='0'> <tr><td align='right'><p style='font-size:28px;'>INVOICE</p></td></tr><tr><td align='right'><p style='font-weight:light'>#INV-" + entity.InvoiceNumber + "</p>");
            sb.Append("</td>");
            sb.Append("</tr></table></td>");
            sb.Append("</table>");
            sb.Append("<br>");
            sb.Append("<table width='100%' cellpadding='-2'>");
            sb.Append("<tr><td align='right'><h5><b>BalanceDue</b></h5></td></tr>");
            sb.Append("<tr><td align='right'><p><h4 style='font-weight:light'><b>Rs." + entity.BalanceDue + ".00" + "</b></h4></p></td></tr>");
            sb.Append("</table>");
            sb.Append("<br>");
            sb.Append("<table width='100%' cellspacing ='0' cellpadding='0'>");
            sb.Append("<tr>");
            sb.Append("<td>");
            sb.Append("<table align='left' width='100%' cellspacing ='0' cellpadding='-2'>");
            sb.Append("<tr><td align='left'><p style='color:gray;font-size:11px'>Bill To</p></td>");
            sb.Append("<tr><td align='left'><b><h5 style='font-weight:light'>" + entity.BillTo + "</h5></b></td>");
            sb.Append("</table>");
            sb.Append("</td>");
            sb.Append("<td>");
            sb.Append("<table align='right' width='100%' cellspacing ='0' cellpadding='0'>");
            sb.Append("<tr><td align='right'><p style='color:gray;font-size:11px'>Invoice Date:</p><p style='color:gray;font-size:11px'>Terms:</p><p style='color:gray;font-size:11px'>Due Date:</p></td>");
            sb.Append("<td align='right'><p style='font-weight:light;font-size:11px'>" + entity.InvoiceDate + "</p><p style='font-weight:light;font-size:11px'>Due on Receipt</p><p style='font-weight:light;font-size:11px'>" + entity.DueDate + "</p></td></tr>");
            sb.Append("</table>");
            sb.Append("</td>");
            sb.Append("</tr></table>");
            sb.Append("<br>");
            sb.Append("<table width='100%' cellspacing ='0' cellpadding='2' style='border-spacing: 0.5px'>");
            sb.Append("<tr bgcolor='#404040'>");
            sb.Append("<th style='text-align:center;border: 1px solid #ddd;font-size:11px'><font color='white'>#</font></th><th style='text-align:center;border: 1px solid #ddd;font-size:11px'><font color='white'>Item & Description</font></th ><th style='text-align:center;border: 1px solid #ddd;font-size:11px'><font color='white'>Quantity</font></th><th style='text-align:center;border: 1px solid #ddd;font-size:11px'><font color='white'>Rate</font></th><th style='text-align:center;border: 1px solid #ddd;font-size:11px'><font color='white'>Amount</font></th>");
            sb.Append("</tr>");

            foreach (var item in Items)
            {
                sb.Append("<tr bgcolor='#f2f2f2' border='0.0001'>");
                sb.Append("<td style='text-align:center;border: 1px solid #ddd;'>" + item.ItemId + "</td>");
                sb.Append("<td style='text-align:center;border: 1px solid #ddd;'>" + item.Description + "</td>");
                sb.Append("<td style='text-align:center;border: 1px solid #ddd;'>" + item.Quantity + "</td>");
                sb.Append("<td style='text-align:center;border: 1px solid #ddd;'>" + item.Rate + "</td>");
                sb.Append("<td style='text-align:center;border: 1px solid #ddd;'>" + item.Amount + "</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("<table align='right' width='37.5%' cellspacing ='0' cellpadding='0'>");
            sb.Append("<tr><td align='center'><p style='font-size:11px'>Sub Total</p><br><p style='font-size:11px'>Shipping Charge</p><br><p style='font-size:11px'>Adjustment</p><br><p style='font-size:11px'><b>Total</b></p><br><p style='font-size:14px'><b>Balance Due</b></p></td>");
            sb.Append("<td align='center'><p style='font-size:11px'>" + entity.SubTotal + "</p><br><p style='font-size:11px'>" + entity.ShippingCharges + "</p><br><p style='font-size:11px'>" + entity.Adjustments + "</p><br><p style='font-size:11px'>" + entity.Total + "</p><br><p style='font-size:14px;'>" + entity.BalanceDue + "</p></td></tr>");
            sb.Append("</table>");
            sb.Append("<br>");
            sb.Append("<br>");
            sb.Append("<table align='left' width='37.5%'>");
            sb.Append("<tr><td align='center'><p style='font-weight:light;color:gray;font-size:11px'>Notes</p></td>");
            sb.Append("<tr><td align='center'><p style='font-size:10px'><mark style='background-color:gray'>Thanks for your business</mark></p><br></td>");
            sb.Append("</table>");
            GetPDF(sb.ToString());
        }
        public void GetPDF(string pHTML)
        {
            //byte[] bPDF = null;
            FileStream fs = new FileStream("Invioce.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            // MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class  
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file  
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, fs);

            // 3: we create a worker parse the document  
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document  
            doc.Open();
            htmlWorker.StartDocument();


            // 5: parse the html into the document  
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker  
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            //bPDF = fs.ToArray();

            // return bPDF;
        }

        public static void GenerateInvoice(InvoiceEntity entity)
        {
            PdfGenerator pd = new PdfGenerator();
            pd.GeneratePDF(entity);

        }
    }
}
