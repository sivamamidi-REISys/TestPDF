using PDFUtilities_Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPDFUtilities
{
    class Program
    {
        static void Main(string[] args)
        {

            InvoiceEntity entity = new InvoiceEntity();
            PdfGenerator.GenerateInvoice(entity);
        }
    }
}
