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
            
            // string text = @"INVOICE";
            Paragraph paragraph = new Paragraph("INVOICE");
            // paragraph.SpacingBefore = 600;
            // paragraph.SpacingAfter = 10;
            paragraph.Alignment = Element.ALIGN_RIGHT;
            paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 0, BaseColor.BLACK);
          
            //paragraph.Add(text);
            document.Add(paragraph);

            Paragraph paragraph1 = new Paragraph("INV-" + entity.InvoiceNumber);
            paragraph1.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph1);
            document.Add(new Phrase("\n"));
            Paragraph paragraph2 = new Paragraph("BalanceDue");
            paragraph2.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph2);

            Paragraph paragraph3 = new Paragraph("RS." + entity.BalanceDue);
            paragraph3.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph3);

            Paragraph paragraph4 = new Paragraph("Invoice Date     :" + entity.InvoiceDate);
            paragraph4.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph4);

            Paragraph paragraph6 = new Paragraph("Bill To :");
            paragraph6.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph6);

            Paragraph paragraph7 = new Paragraph(entity.BillTo);
            paragraph7.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph7);

            Paragraph paragraph5 = new Paragraph("DueDate          :" + entity.DueDate);
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
            // cellid.BorderWidth = 1;
            cellid.BorderColor = BaseColor.LIGHT_GRAY;
            //cellid.BackgroundColor = BaseColor.BLACK;
            //cellid.F
            cellid.Padding = 3;

            PdfPCell cellname = new PdfPCell(new Phrase("Item & Description"));
            cellname.HorizontalAlignment = Element.ALIGN_CENTER;
            cellname.BackgroundColor = BaseColor.WHITE;
            // cellname.BorderWidth = 1;
            cellname.BorderColor = BaseColor.LIGHT_GRAY;
            cellname.Padding = 3;

            PdfPCell qty = new PdfPCell(new Phrase("Quantity"));
            qty.HorizontalAlignment = Element.ALIGN_CENTER;
            qty.BackgroundColor = BaseColor.WHITE;
            // qty.BorderWidth = 1;
            qty.BorderColor = BaseColor.LIGHT_GRAY;
            qty.Padding = 3;

            PdfPCell rate = new PdfPCell(new Phrase("Rate"));
            rate.HorizontalAlignment = Element.ALIGN_CENTER;
            rate.BackgroundColor = BaseColor.WHITE;
            // rate.BorderWidth = 1;
            rate.BorderColor = BaseColor.LIGHT_GRAY;
            rate.Padding = 3;

            PdfPCell amt = new PdfPCell(new Phrase("Amount"));
            amt.HorizontalAlignment = Element.ALIGN_CENTER;
            amt.BackgroundColor = BaseColor.WHITE;
            // amt.BorderWidth = 1;
            amt.BorderColor = BaseColor.LIGHT_GRAY;
            amt.Padding = 3;

            //add cells to the tables
            table.AddCell(cellid);
            table.AddCell(cellname);
            table.AddCell(qty);
            table.AddCell(rate);
            table.AddCell(amt);


            foreach (var Item in entity.Items)
            {

                //PdfPTable table2 = new PdfPTable(5);
                //table2.SpacingAfter = 5;
                //table2.SpacingBefore = 5;
                //table2.TotalWidth = PageSize.A4.Width;
                //table2.LockedWidth = true;

                PdfPCell id = new PdfPCell(new Phrase(Item.ItemId));
                id.HorizontalAlignment = Element.ALIGN_CENTER;
                id.BackgroundColor = BaseColor.WHITE;
                // id.BorderWidth = 1;
                id.BorderColor = BaseColor.LIGHT_GRAY;
                id.Padding = 3;
                table.AddCell(id);

                PdfPCell desc = new PdfPCell(new Phrase(Item.Description));
                desc.HorizontalAlignment = Element.ALIGN_CENTER;
                desc.BackgroundColor = BaseColor.WHITE;
                // desc.BorderWidth = 1;
                desc.BorderColor = BaseColor.LIGHT_GRAY;
                desc.Padding = 3;
                table.AddCell(desc);


                PdfPCell quantity = new PdfPCell(new Phrase(Item.Quantity.ToString()));
                quantity.HorizontalAlignment = Element.ALIGN_CENTER;
                quantity.BackgroundColor = BaseColor.WHITE;
                //  quantity.BorderWidth = 1;
                quantity.BorderColor = BaseColor.LIGHT_GRAY;
                quantity.Padding = 3;
                table.AddCell(quantity);

                PdfPCell itemRate = new PdfPCell(new Phrase(Item.Rate.ToString()));
                itemRate.HorizontalAlignment = Element.ALIGN_CENTER;
                itemRate.BackgroundColor = BaseColor.WHITE;
                //   itemRate.BorderWidth = 1;
                itemRate.BorderColor = BaseColor.LIGHT_GRAY;
                itemRate.Padding = 3;
                table.AddCell(itemRate);

                PdfPCell amount = new PdfPCell(new Phrase(Item.Amount.ToString()));
                amount.HorizontalAlignment = Element.ALIGN_CENTER;
                amount.BackgroundColor = BaseColor.WHITE;
                //   amount.BorderWidth = 1;
                amount.BorderColor = BaseColor.LIGHT_GRAY;
                amount.Padding = 3;
                table.AddCell(amount);

            }

            document.Add(table);


            Paragraph paragraph8 = new Paragraph("SubTotal                            " + entity.SubTotal);
            paragraph8.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph8);

            Paragraph paragraph9 = new Paragraph("Shipping Charge                     " + entity.ShippingCharges);
            paragraph9.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph9);

            Paragraph paragraph10 = new Paragraph("Adjustment                         " + entity.Adjustments);
            paragraph10.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph10);

            Paragraph paragraph11 = new Paragraph("Total                              " + entity.Total);
            paragraph11.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph11);

            Paragraph paragraph12 = new Paragraph("BalanceDue                         " + entity.BalanceDue);
            paragraph12.Alignment = Element.ALIGN_RIGHT;
            document.Add(paragraph12);

            Paragraph paragraph13 = new Paragraph("              Notes");
            paragraph13.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph13);

            Paragraph paragraph14 = new Paragraph("Thanks for your business");
            paragraph14.Alignment = Element.ALIGN_LEFT;
            document.Add(paragraph14);
            document.Close();

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