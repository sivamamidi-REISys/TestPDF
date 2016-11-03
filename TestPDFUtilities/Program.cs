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
            List<ProductItemEntity> productEntities = new List<ProductItemEntity>();

            productEntities.Add(
                new ProductItemEntity { ItemId = "a123", Description = "abcde", Quantity = 1, Rate = 1000, Amount = 5000 });

            productEntities.Add(
                new ProductItemEntity { ItemId = "b1234", Description = "xyzzzz", Quantity = 2, Rate = 5000, Amount = 10000 });

            InvoiceEntity entity = new InvoiceEntity() { InvoiceNumber="1234",InvoiceDate=DateTime.Now,DueDate=DateTime.Now,InvoiceAmount=5000,BillTo="Test",Items= productEntities,SubTotal=5000,ShippingCharges=100,ServiceTax=50,ServiceCharges=25,Adjustments=10,Total=5500,BalanceDue=4500 };

            PdfGenerator.GenerateInvoice(entity);
        }
    }
}
//ProductItemEntity productEntities = new ProductItemEntity{ItemId="a123",Description="abcde",Quantity=1,Rate=1000,Amount=5000};
