using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFUtilities_Legacy
{
    public class PdfGenerator
    {
        public static void GenerateInvoice(InvoiceEntity entity)
        {

            FileStream fs = new FileStream("Invioce.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            string text = @"INVOICE";
            Paragraph paragraph = new Paragraph();
           // paragraph.SpacingBefore = 600;
           // paragraph.SpacingAfter = 10;
            paragraph.Alignment = Element.ALIGN_RIGHT;
            paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.BLACK);
            paragraph.Add(text);
            document.Add(paragraph);

            Paragraph paragraph1 = new Paragraph("INV-"+entity.InvoiceNumber);
            paragraph1.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph1);

            Paragraph paragraph2 = new Paragraph("BalanceDue");
            paragraph2.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph2);

            Paragraph paragraph3 = new Paragraph("RS."+entity.BalanceDue);
            paragraph3.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph3);


            Paragraph paragraph4 = new Paragraph("Invoice Date:"+entity.InvoiceDate);
            paragraph4.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph4);

            Paragraph paragraph6 = new Paragraph("Bill To :");
            paragraph6.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph6);

            Paragraph paragraph7 = new Paragraph(entity.BillTo);
            paragraph7.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph7);

            Paragraph paragraph5 = new Paragraph("DueDate"+entity.DueDate);
            paragraph5.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph5);

            PdfPTable table = new PdfPTable(5);
            table.SpacingAfter = 5;
            table.SpacingBefore = 5;
            table.TotalWidth = PageSize.A4.Width;
            table.LockedWidth = true;

            PdfPCell cellid = new PdfPCell(new Phrase("#"));
            cellid.HorizontalAlignment = Element.ALIGN_CENTER;
            cellid.BackgroundColor = BaseColor.WHITE;
            cellid.BorderWidth = 1;
            cellid.BorderColor = BaseColor.BLACK;
            cellid.Padding = 3;

            PdfPCell cellname = new PdfPCell(new Phrase("Item & Description"));
            cellname.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellname.BackgroundColor = BaseColor.WHITE;
            cellname.BorderWidth = 1;
            cellname.BorderColor = BaseColor.BLACK;
            cellname.Padding = 3;


            PdfPCell qty = new PdfPCell(new Phrase("    Quantity"));
            cellname.HorizontalAlignment = Element.ALIGN_CENTER;
            cellname.BackgroundColor = BaseColor.WHITE;
            cellname.BorderWidth = 1;
            cellname.BorderColor = BaseColor.BLACK;
            cellname.Padding = 3;

            PdfPCell rate = new PdfPCell(new Phrase("    Rate"));
            cellname.HorizontalAlignment = Element.ALIGN_CENTER;
            cellname.BackgroundColor = BaseColor.WHITE;
            cellname.BorderWidth = 1;
            cellname.BorderColor = BaseColor.BLACK;
            cellname.Padding = 3;

            PdfPCell amount = new PdfPCell(new Phrase("    Amount"));
            cellname.HorizontalAlignment = Element.ALIGN_CENTER;
            cellname.BackgroundColor = BaseColor.WHITE;
            cellname.BorderWidth = 1;
            cellname.BorderColor = BaseColor.BLACK;
            cellname.Padding = 3;


            //add cells to the tables
            table.AddCell(cellid);
            table.AddCell(cellname);
            table.AddCell(qty);
            table.AddCell(rate);
            table.AddCell(amount);

            PdfPTable table2 = new PdfPTable(5);

            PdfPCell id = new PdfPCell();
            cellname.HorizontalAlignment = Element.ALIGN_CENTER;
            cellname.BackgroundColor = BaseColor.WHITE;
            cellname.BorderWidth = 1;
            cellname.BorderColor = BaseColor.BLACK;
            cellname.Padding = 3;



            document.Add(table);




            document.Close();
            System.Diagnostics.Process.Start("Invioce.pdf");
        }

    }
}
//PdfPTable table = new PdfPTable(3);
//table.AddCell("Cell 1");
//PdfPCell cell = new PdfPCell(new Phrase("Cell 2", new Font()));
//   cell.BackgroundColor = new Color(0, 150, 0);
//   cell.BorderColor = new color(255, 242, 0);
//cell.Border = Rectangle.BOTTOM_BORDER | Rectangle.TOP_BORDER;
//cell.BorderWidthBottom = 3f;
//cell.BorderWidthTop = 3f;
//cell.PaddingBottom = 10f;
//cell.PaddingLeft = 20f;
//cell.PaddingTop = 4f;
//table.AddCell(cell);
//table.AddCell("Cell 3");
//document.Add(table);

//Chunk chunk = new Chunk("INVOICE");
//document.Add(chunk);
//PdfPTable table = new PdfPTable(1);
//PdfPCell cell = new PdfPCell(new Phrase("Products"));
//table.AddCell(cell);
//List li = new List(List.UNORDERED);
//li.Add("one");
//li.Add("Two");
//document.Add(li);
//     PdfPTable table = new PdfPTable(2);
//table.setSpacingBefore(5);
//table.addCell("List placed directly into cell");
//table.addCell(cell);