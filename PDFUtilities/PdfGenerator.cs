﻿using iTextSharp.text;
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

            FileStream fs = new FileStream("First.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            Document doc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            doc.Add(new Paragraph("Hello World"));
            doc.Close();

        }

    }
}
