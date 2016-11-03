using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFUtilities_Legacy
{
    public class InvoiceEntity
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        
        public double InvoiceAmount { get; set; }

        public string BillTo { get; set; }
        public IList<ProductItemEntity> Items { get; set; }
        public double SubTotal { get; set; }
        public double ShippingCharges { get; set; }
        public double ServiceTax { get; set; }
        public double ServiceCharges { get; set; }
        public double Adjustments { get; set; }
        public double Total { get; set; }
        public double BalanceDue { get; set; }

        public string Notes { get; set; }


}

    public class Customer
    {

    }

    public class ProductItemEntity
    {
        public string ItemId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public double Rate { get; set; }

        public double Amount { get; set; }


    }
}
